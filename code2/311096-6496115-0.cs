    using Newtonsoft.Json.Linq;
    using System;
    
    class Test
    {
        static void Main()
        {
            string json = ConvertToJson("jon", "secret");
            Console.WriteLine(json);
        }
        
        static string ConvertToJson(string login, string password)
        {
            JObject container = new JObject();
            container["jsonrpc"] = "2.0";
            container["method"] = "user.authenticate";
            container["id"] = 2;
            
            JObject p = new JObject();
            p["user"] = login;
            p["password"] = password;
            container["params"] = p;
            return container.ToString();
        }
    
    }
