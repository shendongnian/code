     public IEnumerable<Person> ReadById(int code, string name)
     {
         using (var entities = new Entities())
            return entities.Persons.Where(p => p.Code = code && p.Name = name);
     }
