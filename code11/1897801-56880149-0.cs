        public class Header
        {        
            public string size { get; set; }
            public Content[] content { get; set; }
        }
    
        public class Content
        {
            public string Number { get; set; }
        }
    
        static void Main(string[] args)
        {
                string json = @"{""content"":[{""Number"":""3212012909920002""}],""size"":""1""}";
                dynamic data = JsonConvert.DeserializeObject(json);
                Header obj = JsonConvert.DeserializeObject<Header>(json);
                foreach(var item in obj.content)
                {
                    Console.WriteLine(item.Number);
                }
    
       }
