        [XmlRoot(ElementName="PER")]
    	public class PER {
    		[XmlElement(ElementName="PER01")]
    		public string PER01 { get; set; }
    		[XmlElement(ElementName="PER02")]
    		public string PER02 { get; set; }
    		[XmlElement(ElementName="PER03")]
    		public string PER03 { get; set; }
    		[XmlElement(ElementName="PER04")]
    		public string PER04 { get; set; }
    	}
    
    	[XmlRoot(ElementName="Loop")]
    	public class Loop {
    		[XmlElement(ElementName="PER")]
    		public PER PER { get; set; }
    		[XmlAttribute(AttributeName="LoopId")]
    		public string LoopId { get; set; }
    		[XmlAttribute(AttributeName="Name")]
    		public string Name { get; set; }
    		[XmlElement(ElementName="NM1")]
    		public NM1 NM1 { get; set; }
    	}
    
    	[XmlRoot(ElementName="NM1")]
    	public class NM1 {
    		[XmlElement(ElementName="NM101")]
    		public string NM101 { get; set; }
    		[XmlElement(ElementName="NM102")]
    		public string NM102 { get; set; }
    	}
    
    	[XmlRoot(ElementName="Type")]
    	public class Type {
    		[XmlElement(ElementName="Loop")]
    		public List<Loop> Loop { get; set; }
    	}
