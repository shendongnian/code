    using System.Runtime.Serialization;
    [DataContract]
    public MyObject 
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        public HtmlString MyHtmlContent { get; set; }
        [DataMember(Name = "MyHtmlContent")]
        private string serializedMyHtmlContent
        {
            get { return this.MyHtmlContent == null ? null : MyHtmlContent .ToString(); }
        }
    }
