    XDocument contactDoc = XDocument.Load(m_helpTopicFile);
	var contacts = from xmlTopic in contactDoc.Descendants("Contact")
    select new Contact
						 {
							 Id = int.Parse(xmlTopic.Element("ContactID").Value, CultureInfo.InvariantCulture),
							 Name = xmlTopic.Element("name").Value,
						 };
