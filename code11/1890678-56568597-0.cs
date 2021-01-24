    // Let's say you have a collection of Person objects like this:
    class Person {
        string FirstName { get; set; }
        string LastName { get; set; }
    }
    var peopleByFirstName = collectionOfPeople.OrderBy(x => x.FirstName);
    var peopleByLastThenFirst = collectionOfPeople
        .OrderBy(x => x.LastName)
            .ThenBy(x => x.FirstName)
