    var personDictionary = new Dictionary<string, List<Person>>();
    foreach(var person in personList)
    {
      if (personDictionary.HasKey(person.City)
      {
        personDictionary[person.City].Add(person);
      }
      else
      {
        personDictionary[person.City] = new List<Person>{person};
      }
    }
    
