    IEnumerable<IPerson> people = 
        (persons.Descendants("person")
               .Select(o => 
               { 
                   var p = new Person();
                   p.FirstName = person.Attribute("FName").Value;
                   p.LastName = person.Attribute("LName").Value;
                   return p;
               }).ToList();
