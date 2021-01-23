    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    public struct Element {
        public string data{ get; set; }
        public int size { get; set; }
    }
    
    class Sample {
        static public void Main(){
            const string json =
            @"{ ""error"" : ""0"", 
                ""result"" :
                {
                   ""1256"" : {
                      ""data"" : ""type any data(1256)"", 
                      ""size"" : ""12345""
                   },
                   ""1674"" : {
                      ""data"" : ""type any data(1674)"", 
                      ""size"" : ""45678""
                   },
                }
            }";
            dynamic obj =  JsonConvert.DeserializeObject(json);
            int error = obj.error;
            Console.WriteLine("error:{0}", error);
            dynamic result = obj.result;
            Dictionary<string, Element> dic = new Dictionary<string, Element>();
            foreach(dynamic x in result){
                dynamic y = x.Value;
                dic[x.Name] = new Element { data = y.data, size = y.size};
            }
            //check
            Element el = dic["1674"];
            Console.WriteLine("data:{0}, size:{1}", el.data, el.size);
            el = dic["1256"];
            Console.WriteLine("data:{0}, size:{1}", el.data, el.size);
        }
    }
