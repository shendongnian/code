    List<Person> people = new List<Person>();   /*Populate the list however you wish*/
    List<Phone> phones = new List<Phone>();     /*Populate the list however you wish*/
    
    List<Result> results = people
        .Select(singlePerson => new Result 
        { 
            Name = singlePerson.Name, 
            Numbers = phones
                .Where(singlePhone => singlePhone.PersonId.Equals(singlePerson.PersonId))
                .Select(singlePhone => singlePhone.Number)
                .ToList() 
        })
        .ToList();
