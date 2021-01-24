         var res = Data = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(JSON);
    
       
        public class Customer
        {
            public string phone { get; set; }
        }
        
        
    
        public class Message
        {
            public string type { get; set; }
        }
        
        public class RootObject
        {
            public List<Customer> customer { get; set; }
            public List<Message> message { get; set; }
        }
