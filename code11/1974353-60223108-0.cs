        [XmlRoot(ElementName="price")]
    	public class Price {
    		[XmlAttribute(AttributeName="min")]
    		public string Min { get; set; }
    		[XmlAttribute(AttributeName="max")]
    		public string Max { get; set; }
    		[XmlText]
    		public string Text { get; set; }
    	}
    
    	[XmlRoot(ElementName="data")]
    	public class Data {
    		[XmlElement(ElementName="price")]
    		public Price Price { get; set; }
    		[XmlAttribute(AttributeName="label")]
    		public string Label { get; set; }
    	}
