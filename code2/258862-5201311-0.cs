    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load(@"test.xml");
    var persons = xmlDoc.SelectNodes("persons/person");
    foreach (XmlNode person in persons)
    {
        string firstName = person.SelectSingleNode("firstName").InnerText;
        string middleName = (person.SelectSingleNode("middleName") != null) 
                            ? person.SelectSingleNode("middleName").InnerText 
                            : null;
        string lastName = person.SelectSingleNode("lastName").InnerText;
    }
