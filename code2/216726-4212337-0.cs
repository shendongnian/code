        public static Person LoadPerson (int Id)
        {
            XDocument personXml = XDocument.Load("person.xml");
            var person = (from p in personXml.Descendants("Person")
                          where (int)p.Attribute("id") == Id
                          select new Person
                          {
                              FirstName = (string)p.Element("FirstName"),
                              LastName = (string)p.Element("LastName"),
                              Age = (int)p.Element("Age")
                          }).SingleOrDefault();
    
        }
