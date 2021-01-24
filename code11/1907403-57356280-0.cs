    //you should use your practical namespace to replace this value
      [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/Server1")]
        public class Product
        {
            [DataMember]
            public int ID { get; set; }
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public Color Color { get; set; }
        }
        public enum Color
        {
            Red,
            Green,
            Blue
    }
