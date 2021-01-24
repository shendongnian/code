public static void Main()
{
			XmlDocument doc1 = new XmlDocument();
			doc1.Load(XML1);
			XmlDocument doc2 = new XmlDocument();
			doc2.Load(XML2);
			XmlElement root = doc2.DocumentElement;
			var children1 = doc1.SelectNodes("root/data");
			//var children2 = doc2.SelectNodes("root/data");
			XmlDocument result = new XmlDocument();
			result.Load(ResultFile);
			XmlNode XNode = result.SelectSingleNode("/root");
			for (var d = 0; d < children1.Count; d++) //lista  doc 1
			{
				var child = children1[d];
				XmlNode nodeToFind = root.SelectSingleNode("/data[@name='" + child.Attributes["name"].Value + "']");
				if (nodeToFind == null)
				{
					XNode.AppendChild(result.ImportNode(child, true));
					
				}
			}
			result.Save(ResultFile);
}
