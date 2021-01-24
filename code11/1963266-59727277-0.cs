    using System;
    //Add
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net;
    using Newtonsoft.Json;
    using System.Globalization;
    using IpData;
    using RestSharp;
    namespace ipdata_co_v1
    {
    class Program
    {
        public static void Main()
        {                   
            var client = new 
    RestClient("https://api.ipdata.co/8.8.8.8?api-key=test");
            
            var request = new RestRequest(Method.GET);
            //IRestResponse response = client.Execute(request);
            //To get the data you are looking for, you will 
    first need to deserialize the response.Content.
            //When you call the Rest endpoint, you can call it 
    in a few different ways.
            //var response = client.Execute(request);            
     // 1
            var response = client.Execute<IPData>(request); // 2
            //var obj = 
    JsonConvert.DeserializeObject(response.Content);
            //Console.WriteLine(obj["ip"].Value);  
            Console.WriteLine(response.Data.ip);
            Console.WriteLine(response.Data.latitude);
            Console.WriteLine(response.Data.longitude);
        }
        public class IPData
        {
            public string ip { get; set; }
            public string city { get; set; }
            public string country_name { get; set; }
            public string country_code { get; set; }
            public string continent_name { get; set; }
            public string continent_code { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string flag { get; set; }
            public string time_zone { get; set; }
        }
     }
    }
