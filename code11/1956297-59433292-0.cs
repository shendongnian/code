    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net;
    using Newtonsoft.Json;
    
    
    namespace ConsoleApp2
    {
    
        public class RootObject
        {
            public List<MyList> list { get; set; }
        }
    
        public class MyList
        {
            public Main main { get; set; }
        }
    
        public class Main
        {
            public double temp { get; set; }
        }
    
        class Program
        {
            static void Main()
            {
                using (WebClient client = new WebClient())
                {
                    Console.WriteLine("ACCESSING ...");
                    string test = client.DownloadString("http://api.openweathermap.org/data/2.5/forecast?q=Auckland,NZ&APPID=45c3e583468bf450fc17026d6734507e");
                    //string test = "{\"cod\":\"200\",\"message\":0,\"cnt\":40,\"list\":[{\"dt\":1576810800,\"main\":{\"temp\":288.19,\"feels_like\":284.44,\"temp_min\":288.19,\"temp_max\":291.53,\"{\"dt\":1576821600,\"main\":{ \"temp\":283.97,\"feels_like\":281.56,\"temp_min\":283.97,\"temp_max\":286.47,\"pressure\":1007,\"sea_level\":1007,\"grnd_level\":997,\"humidity\":93,\"temp_kf\":-2.5},\"weather\":[{\"id\":501,\"main\":\"Rain\",\"description\":\"moderate rai\",\"icon\":\"10d\"}],\"clouds\":{\"all\":90},\"wind\"";
    
                    var myobject = JsonConvert.DeserializeObject<RootObject>(test); //test is JSON response as string 
    
                    foreach (var item in myobject.list)
                    {
                        var temp = item.main.temp;
                        Console.WriteLine(temp);
    
    
                    }
    
                    Console.ReadLine();
                }
            }
        }
    }
