    public static IEnumerable<Person> ReadPeople(xmlpath)
    {
        XDocument xd = XDocument.Load(xmlpath);
        return from p in xd.Descendants("person")
               select new Person
               {
                   FirstName = p.Element("firstname").value,
                   LastName = p.Element("lastname").value
               });
    }
