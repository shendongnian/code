    public static Person ReadPerson(xmlpath)
    {
        XDocument xd = XDocument.Load(xmlpath);
        XElement element = xd.Descendants("person").First();
        return new Person
               {
                   FirstName = element.Element("firstname").value,
                   LastName = element.Element("lastname").value
               });
    }
