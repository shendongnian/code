    public static IEnumerable<Person> ReadPeople(xmlpath)
    {
        XDocument xd = XDocument.Load(xmlpath);
        return (from p in xd.Descendants("person")
                select new Person
                {
                    FirstName = (string)p.Element("firstname"),
                    LastName = (string)p.Element("lastname")
                });
    }
