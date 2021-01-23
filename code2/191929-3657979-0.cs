    var predicate = PredicateBuilder.False<Staff_Person>();
    foreach (var staffTerm in staffTermArray)
    {
       // We need to make a local copy because of C# weirdness.
       var ping = staffTerm;
       predicate = predicate.Or(person => person.Forename.Contains(pinq));
       predicate = predicate.Or(person => person.Surname.Contains(pinq));
       predicate = predicate.Or(person => person.Known_as.Contains(pinq));
    }
    var searchResults = 
        from x in SDC.Staff_Persons.Where(predicate)
        orderby x.Surname
        select x;
