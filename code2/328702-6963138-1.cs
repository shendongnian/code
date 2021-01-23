    [DataContract]
    public class MyCustomClass
    {
         [DataMember]
         public string CustomProp { get; set; }
         [DataMember]
         public List<int> Ids { get; set; }
    }
