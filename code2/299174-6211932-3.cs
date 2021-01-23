    [DataContract(Name = "Person")]
    public class Person : IExtensibleDataObject {
       // IEDO implementation skipped, since it's always the same
       [DataMember(Order = 0)] public string Name;
       [DataMember(Order = 1)] public int Age;
    }
