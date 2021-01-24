    using System;
    using System.Net;
    using System.IO;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    
    namespace HttpsApiTest
    {
        class Program
        {
    
            public class ForQuery
            {
                public bool bid { get; set; }
                public List<int> types { get; set; }
                public List<object> regions { get; set; }
                public List<object> systems { get; set; }
                public int hours { get; set; }
                public int minq { get; set; }
            }
    
            public class Buy
            {
                public ForQuery forQuery { get; set; }
                public long volume { get; set; }
                public double wavg { get; set; }
                public double avg { get; set; }
                public double variance { get; set; }
                public double stdDev { get; set; }
                public double median { get; set; }
                public double fivePercent { get; set; }
                public double max { get; set; }
                public double min { get; set; }
                public bool highToLow { get; set; }
                public long generated { get; set; }
            }
    
            public class ForQuery2
            {
                public bool bid { get; set; }
                public List<int> types { get; set; }
                public List<object> regions { get; set; }
                public List<object> systems { get; set; }
                public int hours { get; set; }
                public int minq { get; set; }
            }
    
            public class Sell
            {
                public ForQuery2 forQuery { get; set; }
                public int volume { get; set; }
                public double wavg { get; set; }
                public double avg { get; set; }
                public double variance { get; set; }
                public double stdDev { get; set; }
                public double median { get; set; }
                public double fivePercent { get; set; }
                public double max { get; set; }
                public double min { get; set; }
                public bool highToLow { get; set; }
                public long generated { get; set; }
            }
    
            public class RootObject
            {
                public Buy buy { get; set; }
                public Sell sell { get; set; }
            }
    
            static void Main(string[] args)
            {
                string sURL = "https://api.evemarketer.com/ec/marketstat/json?typeid=1230&regionlimit=10000002";
                StreamReader objReader = new StreamReader(WebRequest.Create(sURL).GetResponse().GetResponseStream());
                string sLine = objReader.ReadLine();
    
                var obj = JToken.Parse(sLine).ToObject<List<RootObject>>();
    
                Console.WriteLine("Buy node:");
    
                Console.WriteLine(" Max: " + obj[0].buy.max);
                Console.WriteLine(" HighToLow: " + obj[0].buy.highToLow);
    
                Console.WriteLine("Sell node:");
    
                Console.WriteLine(" Max: " + obj[0].sell.max);
                Console.WriteLine(" HighToLow: " + obj[0].sell.highToLow);
    
                Console.ReadLine();
            }
        }
    }
