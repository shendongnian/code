cs
var doc = XDocument.Parse(xml);
var dict = new Dictionary<string, Dictionary<string, ConfigFileElements>>();
foreach (var set in doc.Root.Elements())
{
	dict.Add(set.Name.ToString(), ParseSet(set));
}
Dictionary<string, ConfigFileElements> ParseSet(XElement set)
{
	var dict = new Dictionary<string, ConfigFileElements>();
	foreach (var element in set.Elements())
	{
		var config = new ConfigFileElements()
		{
			value = (element.FirstNode as XElement)?.Value,
			defaultValue = (element.LastNode as XElement)?.Value
		};
		dict.Add(element.Name.ToString(), config);
	}
	return dict;
}
