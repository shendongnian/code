	public Task(string xmlSourceAsString):
		this(XElement.Parse(xmlSourceAsString))
	{
	}
	public Task(XElement xmlSource)
	{
		Values=(from itm in xmlSource.Element("Values").Elements("Item") select itm.Value).ToList();
		OtherValues=(from itm in xmlSource.Element("OtherValues").Elements("Item") select itm.Value).ToList();
		Requirement=xmlSource.Element("Requirement").Value;
		Minimum=int.Parse(xmlSource.Element("Minimum").Value);
		Maximum=int.Parse(xmlSource.Element("Maximum").Value);
	}
