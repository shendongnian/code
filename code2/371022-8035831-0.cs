    [DataContract]
    public class MyCustomClass
    {
    }
    [DataContract]
    public class ContentItemViewModel
    {
        [DataMember]
        public string CssClass { get; set; }
        [DataMember]
        public MyCustomClass PropertyB { get; set; }
    }
