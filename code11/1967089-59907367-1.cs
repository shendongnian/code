    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Test
    {
        public class EDetails
        {
            [JsonProperty("title")]
            public string Title { get; set; }
    
            [JsonProperty("value1")]
            public string Value1 { get; set; }
    
            [JsonProperty("objects")]
            public Object Objects { get; set; }
    
            [JsonProperty("lists")]
            public List<List> Lists { get; set; }
    
        }
    
        public class Object
        {
            [JsonProperty("obj1")]
            public string Obj1 { get; set; }
    
            [JsonProperty("obj2")]
            public string Obj2 { get; set; }
    
        }
    
        public class List
        {
            [JsonProperty("date")]
            public string Date { get; set; }
    
            [JsonProperty("time")]
            public string Time { get; set; }
        }
        class Program
        {
    
            static void Main(string[] args)
            {
                string FilePath = @"C: \Users\Win10EGL\source\repos\Test\testJson.json";
                int count = 0;
                var rootObject = JsonConvert.DeserializeObject<EDetails>(File.ReadAllText(FilePath));
                var item = rootObject.Lists[0].Date;
                foreach(var element in rootObject.Lists.ToList())
                {
                    Console.WriteLine(rootObject.Lists[count].Date + " " + rootObject.Lists[count].Time);
                    count++;
                }
                Console.Read();
            }
    
        }
    }
    
    
