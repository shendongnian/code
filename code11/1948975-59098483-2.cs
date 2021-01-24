        [DataContract(Namespace ="ABCD")]
        public class Product
        {
            [DataMember]
            public int ID { get; set; }
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public string Description { get; set; }
            [DataMember]
            public decimal Price { get; set; }
    }
