	[XmlRoot("searchReturn")]
	public class SearchReturn
	{
		[XmlElement("SummaryData_Version1_1Impl", typeof(SummaryData))]
		public SummaryData[] searchReturn;
	}
	public SearchReturn GetData(string xmlString)
	{
		System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
		doc.LoadXml(xmlString);
		System.Xml.XmlNode DataNode = doc.SelectSingleNode("//searchReturn");
		System.Xml.XmlDocument processedDoc = new System.Xml.XmlDocument();
		processedDoc.AppendChild(processedDoc.ImportNode(DataNode, true));
		SearchReturn data = Deserialize<SearchReturn>(processedDoc);
		return data;
	}
