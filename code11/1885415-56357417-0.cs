	// Parse your XML string
	var doc = XDocument.Parse(xml);
	// Find the first child of type "Day", whose child of type "DayID" has the value "24-2"
	var toRemove = doc.Root
		.Descendants("Day")
		.FirstOrDefault(x => x.Element("DayID").Value == "24-2"); 
	// Remove it
	toRemove?.Remove();
    string result = doc.ToString();
