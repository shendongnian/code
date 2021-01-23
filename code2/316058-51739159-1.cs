    // PM>Install-Package System.Json -Version 4.5.0
    
    using System;
    using System.Json;
    
    namespace NetCoreTestConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Note that json keys are case sensitive, a is not same as A.
    
                // Json Sample
                string jsonString = "{\"a\": 1,\"b\": \"string value\",\"c\":[{\"Value\": 1}, {\"Value\": 2,\"SubObject\":[{\"SubValue\":3}]}]}";
                
                // Verify your json if you get any errors here
                JsonValue json = JsonValue.Parse(jsonString);
    
                // int test
                if (json.ContainsKey("a"))
                {
                    int a = json["a"]; // type already set to int
                    Console.WriteLine("json[\"a\"]" + " = " + a);
                }
    
                // string test
                if (json.ContainsKey("b"))
                {
                    string b = json["b"];  // type already set to string
                    Console.WriteLine("json[\"b\"]" + " = " + b);
                }
    
                // object array test
                if (json.ContainsKey("c") && json["c"].JsonType == JsonType.Array)
                {
                    // foreach loop test
                    foreach (JsonValue j in json["c"])
                    {
                        Console.WriteLine("j[\"Value\"]" + " = " + j["Value"].ToString());
                    }
    
                    // multi level key test
                    Console.WriteLine("json[\"c\"][0][\"Value\"]" + " = " + json["c"][0]["Value"].ToString());
                    Console.WriteLine("json[\"c\"][0][\"Value\"]" + " = " + json["c"][1]["Value"].ToString());
                    Console.WriteLine("json[\"c\"][1][\"SubObject\"][0][\"SubValue\"]" + " = " + json["c"][1]["SubObject"][0]["SubValue"].ToString());
    
    
                }
    
                Console.WriteLine();
                Console.Write("Press any key to exit.");
                Console.ReadKey();
            }
    
        }
    }
