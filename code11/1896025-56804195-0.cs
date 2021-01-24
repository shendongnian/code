    /* 
    Licensed under the Apache License, Version 2.0
    
    http://www.apache.org/licenses/LICENSE-2.0
    */
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace Xml2CSharp
    {
	[XmlRoot(ElementName="Translation", Namespace="urn:Test.Translations")]
	public class Translation {
		[XmlAttribute(AttributeName="key")]
		public string Key { get; set; }
		[XmlText]
		public string Text { get; set; }
	}
	[XmlRoot(ElementName="Section", Namespace="urn:Test.Translations")]
	public class Section {
		[XmlElement(ElementName="Translation", Namespace="urn:Test.Translations")]
		public List<Translation> Translation { get; set; }
		[XmlAttribute(AttributeName="name")]
		public string Name { get; set; }
	}
	[XmlRoot(ElementName="Translations", Namespace="urn:Test.Translations")]
	public class Translations {
		[XmlElement(ElementName="Section", Namespace="urn:Test.Translations")]
		public List<Section> Section { get; set; }
		[XmlAttribute(AttributeName="code")]
		public string Code { get; set; }
		[XmlAttribute(AttributeName="description")]
		public string Description { get; set; }
		[XmlAttribute(AttributeName="xmlns")]
		public string Xmlns { get; set; }
	}
    }
