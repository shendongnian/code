    [DataContract]
    public class MyClass
    {
         [DataMember(IsRequired = true, Order = 1)]
         public int Id { get; set; }
    }
