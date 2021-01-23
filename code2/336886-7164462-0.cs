    var predicate = PredicateBuilder.True<User>();
    if (!string.IsNullOrWhitespace(username))
        predicate = predicate.And(a => a.Username == username);
    if (!string.IsNullOrWhitespace(whatever))
        predicate = predicate.And(a => a.Whatever == whatever);
    /* etc. etc. */
    var filteredUsers = myUsers.Where(predicate);
