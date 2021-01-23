	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Xml;
	using System.Xml.XPath;
	
	namespace My.Shared.Utilities {
		public static class XmlExtensions {
			public static void SetAttribute(this XPathNavigator nav, string localName, string namespaceURI, string value) {
				if (!nav.MoveToAttribute(localName, namespaceURI)) {
					throw new XmlException("Couldn't find attribute '" + localName + "'.");
				}
				nav.SetValue(value);
				nav.MoveToParent();
			}
		}
	}
