    [DataContract(Name = "Person")]
    public class Person : IExtensibleDataObject {
       ExtensionDataObject IExtensibleDataObject.ExtensionData { get; set; }
       [DataMember(Order = 0)] public string Name;
       [DataMember(Order = 1)] public int Age;
    }
