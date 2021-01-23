    var interestTagsOfPerson = context.People.Where(p => p.Id == givenPersonId)
        .Select(p => p.InterestTags.Select(t => t.Id))
        .SingleOrDefault();
    // Result is an IEnumerable<int> which contains the Id of the tags of this person
    var posts = context.Posts
        .Where(p => p.InterestTags.Any(t => interestTagsOfPerson.Contains(t.Id)))
        .ToList();
    // Contains translates into an IN clause in SQL
