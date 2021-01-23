    [DataContract(Name="Person")]
    public class Person_V1 : IExtensibleDataObject
    {
        [DataMember(Name = "Name")]
        public string Name;
        [DataMember(Name = "Age")]
        public int Age;
        public ExtensionDataObject ExtensionData { get; set; }
    }
