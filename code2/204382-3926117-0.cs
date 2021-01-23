    [DataContract]
    public class SomeJsonyThing
    {
        [DataMember(Name="my_element")]
        public string MyElement { get; set; }
    
        [DataMember(Name="my_nested_thing")]
        public object MyNestedThing { get; set;}
    }
