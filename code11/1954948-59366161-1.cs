    [XmlRoot(ElementName="EC")]
    public class EC 
    {
    		[XmlElement(ElementName="ECID")]
    		public string ECID { get; set; }
    		[XmlElement(ElementName="ECNAME")]
    		public string ECNAME { get; set; }
    		[XmlElement(ElementName="ECDEF")]
    		public string ECDEF { get; set; }
    		[XmlElement(ElementName="ECSLL")]
    		public string ECSLL { get; set; }
    		[XmlElement(ElementName="ECSUL")]
    		public string ECSUL { get; set; }
    		[XmlElement(ElementName="ECWLL")]
    		public string ECWLL { get; set; }
    		[XmlElement(ElementName="ECWUL")]
    		public string ECWUL { get; set; }
    }
    
    [XmlRoot(ElementName="ECS")]
    public class ECS 
    {
    		[XmlElement(ElementName="EC")]
    		public List<EC> EC { get; set; }
    }
    
    [XmlRoot(ElementName="BODY")]
    public class BODY 
    {
    		[XmlElement(ElementName="EQPID")]
    		public string EQPID { get; set; }
    		[XmlElement(ElementName="ECS")]
    		public ECS ECS { get; set; }
    }
    
    [XmlRoot(ElementName="MESSAGE")]
    public class MESSAGE 
    {
    		[XmlElement(ElementName="NAME")]
    		public string NAME { get; set; }
    		[XmlElement(ElementName="BODY")]
    		public BODY BODY { get; set; }
    }
