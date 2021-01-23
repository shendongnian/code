    List<IPerson> people = new List<IPerson>();
    people.Add(new ImmortalPerson());
    people.Add(new RegularPerson());
    foreach (var person in people)
    {
       if (person is IAgeable)
       {
          ((IAgeable)person).AgeAYear();
       }
    }
