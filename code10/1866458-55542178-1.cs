    Int64 memberId = reader.GetInt64(0);
    var user = Context.Guild.Users
        .Where(x => x.Id == (UInt64)memberId)
        .First();
    
    string name = 
        user.Nickname != null 
            ? user.Nickname 
            : user.Username;
    
    Int64 votes = reader.GetInt64(2);
    GOTWVote.Add($@"{name} has received {votes} vote(s)");
