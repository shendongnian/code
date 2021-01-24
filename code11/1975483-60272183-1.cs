    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
        public class Program
        {
        
            static string jsonStr = "{" +
                        "    \"count\":500," +
                        "    \"type\":\"table\"," +
                        "    \"data1\": {" +
                        "        \"name\":\"test123\"," +
                        "        \"comments\":\"test123\"," +
                        "        \"id\":\"123\"      " +
                        "    }," +
                        "    \"data2\":{" +
                        "        \"env\":\"dev\"," +
                        "        \"status\":\"new\"" +
                        "    }" +
                        "}";
            public class Data1
            {
                public string name { get; set; }
                public string comments { get; set; }
                public string id { get; set; }
            }
            public class Data2
            {
                public string env { get; set; }
                public string status { get; set; }
                
                // Additional property
                public string priority { get; set; }
            }
            public class RootObject
            {
                public int count { get; set; }
                public string type { get; set; }
                public Data1 data1 { get; set; }
                public Data2 data2 { get; set; }
            }
            static void Main(string[] args)
            {
                // Replace Program.jsonStr with your data from awaited context
                RootObject obj = JsonConvert.DeserializeObject<RootObject>(Program.jsonStr);
                obj.data2.priority = "none";
                Console.ReadKey();
            }
        }
    }
