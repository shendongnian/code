    using System;
    using System.Json;
    namespace NetCoreTestConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                string jsonString = "{\"a\": 1,\"b\": \"z\",\"c\":[{\"Value\": 1}, {\"Value\": 2}]}";
                JsonValue json = JsonValue.Parse(jsonString);
                // int test
                if (json.ContainsKey("a"))
                {
                    int a = json["a"]; // type already set to int
                    Console.WriteLine(a);
                }
                // string test
                if (json.ContainsKey("b"))
                {
                    string b = json["b"];  // type already set to string
                    Console.WriteLine(b);
                }
                // object array test
                if (json.ContainsKey("c") && json["c"].JsonType == JsonType.Array)
                {
                    foreach (JsonValue j in json["c"])
                    {
                        Console.WriteLine(j["Value"].ToString());
                    }
                }
                Console.WriteLine();
                Console.Write("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
