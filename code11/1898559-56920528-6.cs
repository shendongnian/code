    var personNicknames = people.SelectMany(person => person.Nicknames
    	    .Select(nickname => new { person, nickname }));
    var groupedPersonNicknames = personNicknames.GroupBy(i => i.nickname);
    var duplicatePeople = groupedPersonNicknames.SelectMany(i => 
            i.OrderBy(j => j.person.Priority)
            .Skip(1).Select(j => j.person)
        );
    var distinctPeople = people.Except(duplicatePeople);
