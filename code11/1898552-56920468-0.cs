    var uniqueNicknames = new HashSet<string>();
    IEnumerable<Person> uniquePeople = people
        .OrderBy(T => T.Priority) // ByDescending?
        .Where(T => T.Nicknames.All(N => !uniqueNicknames.Contains(N)))
        .Where(T => T.Nicknames.All(N => uniqueNicknames.Add(N)));
