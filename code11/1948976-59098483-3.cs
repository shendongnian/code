        [DataContract(Namespace ="ABCD")]
        public class Product:IExtensibleDataObject
        {
            [DataMember]
            public int ID { get; set; }
            [DataMember]
            public string Name { get; set; }
            public ExtensionDataObject ExtensionData { get; set; }
            //[DataMember]
            //public string Description { get; set; }
            //[DataMember]
            //public decimal Price { get; set; }
    }
