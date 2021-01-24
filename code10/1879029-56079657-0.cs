    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    
    class Program
    {
        static void Main()
        {
            var json = File.ReadAllText("test.json");
            var reports = JsonConvert.DeserializeObject<Dictionary<string, ReportData>>(json);
            
            foreach (var pair in reports)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value.ApiKey}");
            }
        }
    }
    
    public class ReportData
    {
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }
    }
