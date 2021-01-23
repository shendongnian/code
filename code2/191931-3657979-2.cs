    var filter = CreateFilter(staffTermArray);
    var searchResults = 
        from person in SDC.Staff_Persons.Where(filter)
        orderby person.Surname
        select person;
    private static Expression<Func<Staff_Person, bool>> CreateFilter(
        string[] staffTermArray)
    {
        var predicate = PredicateBuilder.False<Staff_Person>();
        foreach (var staffTerm in staffTermArray)
        {
           // We need to make a local copy because of C# weirdness.
           var ping = staffTerm;
           predicate = predicate.Or(p => p.Forename.Contains(ping));
           predicate = predicate.Or(p => p.Surname.Contains(ping));
           predicate = predicate.Or(p => p.Known_as.Contains(ping));
        }
        return predicate;
    }
