			String xml = "<someXml />";
			using(StringReader textReader = new StringReader(xml)) {
				using(XmlTextReader xmlReader = new XmlTextReader(textReader)) {
					xmlReader.MoveToContent();
					xmlReader.Read();
					// the reader is now pointed at the first element in the document...
				}
			}
