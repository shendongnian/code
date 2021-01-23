    var userCollection = new Collection<string>();
    var users = UserRepository.ALL() 
    foreach (var part in new [] { 'Ha', 'Ho', 'He' }) 
    { 
        string part1 = part; // "Copy" since we're coding lazily 
        var matches = users.Where(x => x.LastName.StartsWith(part1) || 
                                 x.FirstName.StartsWith(part1)); 
        foreach (var i in matches)
        {
            userCollection.Add(i);
        }
    } 
