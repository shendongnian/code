		private XmlDocument StripNamespace(XmlDocument doc)
		{
			if (doc.DocumentElement.NamespaceURI.Length > 0)
			{
				doc.DocumentElement.SetAttribute("xmlns", "");
				// must serialize and reload for this to take effect
				XmlDocument newDoc = new XmlDocument();
				newDoc.LoadXml(doc.OuterXml);
				return newDoc;
			}
				else return doc;
		}
