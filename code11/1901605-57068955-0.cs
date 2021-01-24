            [OperationContract]
            [WebInvoke(ResponseFormat =WebMessageFormat.Json,RequestFormat =WebMessageFormat.Json)]
            List<Product> SayHello();
    
        public class Product
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public List<Animal> Animals { get; set; }
    
    
        }
        public class Animal
        {
            public int ID { get; set; }
            public string Name { get; set; }
    
    }
