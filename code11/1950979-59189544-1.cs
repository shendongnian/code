    [DataContract]
        public class Product
        {
            [DataMember(Order = 3)]
            public int ID { get; set; }
            [DataMember(Order = 5)]
            public string Name { get; set; }
    }
