    [DataContract(Name = "Person")]
    public class Person_V2 : IExtensibleDataObject {
       ExtensionDataObject IExtensibleDataObject.ExtensionData { get; set; }
       [DataMember(Order = 0)] public string Name;
       [DataMember(Order = 1)] public int Age;
       [DataMember(Order = 2)] public string Address;
    }
