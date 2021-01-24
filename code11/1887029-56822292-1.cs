    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using unirest_net.http;
    using unirest_net;
    using Newtonsoft.Json.Linq;
    
    namespace NBA_test
    {
        public class Program
        {
    
            public static void Main(string[] args)
            {
    
                Console.WriteLine("Start of Program...");
    
                HttpResponse<string> response = Unirest.get("https://api-nba-v1.p.rapidapi.com/gameDetails/9999")
                .header("X-RapidAPI-Host", "api-nba-v1.p.rapidapi.com")
                .header("X-RapidAPI-Key", "myKey")
                .asJson<string>();
    
                var result = response.Body;
    
                JObject parsedString = JObject.Parse(result);
    
                RootObject myGame = parsedString.ToObject<RootObject>();
    
                // Get game id
                Console.WriteLine(myGame.results[0].gameId);
    
                Console.WriteLine("End of Program....");
            }
        }
    }
