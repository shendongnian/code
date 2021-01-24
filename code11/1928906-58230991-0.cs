    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace WorkingProject
    {
    	[XmlRoot(ElementName="child1")]
    	public class Child1 {
    		[XmlAttribute(AttributeName="id")]
    		public string Id { get; set; }
    	}
    
    	[XmlRoot(ElementName="child111")]
    	public class Child111 {
    		[XmlAttribute(AttributeName="id")]
    		public string Id { get; set; }
    	}
    
    	[XmlRoot(ElementName="child11")]
    	public class Child11 {
    		[XmlElement(ElementName="child111")]
    		public Child111 Child111 { get; set; }
    		[XmlAttribute(AttributeName="id")]
    		public string Id { get; set; }
    	}
    
    	[XmlRoot(ElementName="child2")]
    	public class Child2 {
    		[XmlElement(ElementName="child11")]
    		public Child11 Child11 { get; set; }
    	}
    
    	[XmlRoot(ElementName="child")]
    	public class Child {
    		[XmlElement(ElementName="child1")]
    		public Child1 Child1 { get; set; }
    		[XmlElement(ElementName="child2")]
    		public Child2 Child2 { get; set; }
    		[XmlAttribute(AttributeName="id")]
    		public string Id { get; set; }
    	}
    
    	[XmlRoot(ElementName="root")]
    	public class Root {
    		[XmlElement(ElementName="child")]
    		public List<Child> Child { get; set; }
    	}
    
    }
