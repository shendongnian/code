    [DataContract]
    public class Foo : Bar
    {
        [DataMember]
        string one { get; set; }
        string two { get; set; }
        [DataMember]
        string three { get; set; }
    }
