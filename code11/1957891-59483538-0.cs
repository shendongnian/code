        [DataContract(Namespace="abcd")]
        public class Product: IExtensibleDataObject
        {
            [DataMember]
            public int ID { get; set; }
            [DataMember]
            public string Name { get; set; }
            public ExtensionDataObject ExtensionData { get ; set ; }
    }
