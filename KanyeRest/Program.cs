using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace KanyeRest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            static void KanyeQuote()
            {
                var KanyeURL = "https://api.kanye.rest";

                var client = new HttpClient();
                var kanyeResponse = client.GetStringAsync(KanyeURL).Result;


                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

                Console.WriteLine($"Kanye says : {kanyeQuote}");
            }


            static void RonQuote()
            {
                var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

                var client1 = new HttpClient();

                var ronResponse = client1.GetStringAsync(ronURL).Result;

                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

                Console.WriteLine($"Chuck says : {ronQuote}");
            }


            var response = "";
            do
            {
                KanyeQuote();
                RonQuote();
                Console.WriteLine("Do you want another set of quotes \n type No to quit \n anything else to continue");
                response = Console.ReadLine();

            } while (response.ToLower() != "no");
            

        }
    }
}
