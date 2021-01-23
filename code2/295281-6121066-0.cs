    public static List<Person> ReadPerson(xmlpath)
    {
        XDocument xd = XDocument.Load(xmlpath);
        /*var person = (from p in xd.Descendants("person")
                      select new Person
                      {
                          FirstName = p.Element("firstname").value,
                          LastName = p.Element("lastname").value
                      });*/
        List<Person> persons = (from p in xd.Descendants("person")
                      select new Person
                      {
                          FirstName = p.Element("firstname").value,
                          LastName = p.Element("lastname").value
                      }).ToList();
        return persons;
    }
