    using System;
    using Newtonsoft.Json.Linq;
    
    class Test
    {
        static void Main()
        {
            string json = "{\"FullName\":\"Mr Mahesh Sharma\",\"Miles\":0,\"TierStatus\":\"IO\"," +
                "\"TierMiles\":0,\"MilesExpiry\":0,\"ExpiryDate\":\"30/03/2012 00:00:00\"," + 
                "\"AccessToken\":\"106C9FD143AFA6198A9EBDC8B9CC0FB2CE867356222D21D45B16BEE" + 
                "B9A7F390B5E226665851D6DB9\",\"ActiveCardNo\":\"00300452124\",\"PersonID\":8654110}";
            
            JObject parsed = JObject.Parse(json);
            
            foreach (var pair in parsed)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        }
    }
