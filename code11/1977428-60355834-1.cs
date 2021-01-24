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
			value = element.Elements("value")?.FirstOrDefault()?.Value,
			//parse min/max on the same way
			defaultValue = element.Elements("defaultValue")?.FirstOrDefault()?.Value
		};
		dict.Add(element.Name.ToString(), config);
	}
	return dict;
}
