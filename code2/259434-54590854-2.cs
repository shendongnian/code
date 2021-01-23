       /* 
		Licensed under the Apache License, Version 2.0
		
		http://www.apache.org/licenses/LICENSE-2.0
		*/
	using System;
	using System.Xml.Serialization;
	using System.Collections.Generic;
	namespace Xml2CSharp
	{
		[XmlRoot(ElementName="shipto")]
		public class Shipto {
			[XmlElement(ElementName="name")]
			public string Name { get; set; }
			[XmlElement(ElementName="address")]
			public string Address { get; set; }
			[XmlElement(ElementName="city")]
			public string City { get; set; }
			[XmlElement(ElementName="country")]
			public string Country { get; set; }
		}
		[XmlRoot(ElementName="item")]
		public class Item {
			[XmlElement(ElementName="title")]
			public string Title { get; set; }
			[XmlElement(ElementName="note")]
			public string Note { get; set; }
			[XmlElement(ElementName="quantity")]
			public string Quantity { get; set; }
			[XmlElement(ElementName="price")]
			public string Price { get; set; }
		}
		[XmlRoot(ElementName="shiporder")]
		public class Shiporder {
			[XmlElement(ElementName="orderperson")]
			public string Orderperson { get; set; }
			[XmlElement(ElementName="shipto")]
			public Shipto Shipto { get; set; }
			[XmlElement(ElementName="item")]
			public List<Item> Item { get; set; }
			[XmlAttribute(AttributeName="noNamespaceSchemaLocation", Namespace="http://www.w3.org/2001/XMLSchema-instance")]
			public string NoNamespaceSchemaLocation { get; set; }
			[XmlAttribute(AttributeName="orderid")]
			public string Orderid { get; set; }
			[XmlAttribute(AttributeName="xsi", Namespace="http://www.w3.org/2000/xmlns/")]
			public string Xsi { get; set; }
		}
	}
