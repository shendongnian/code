    Int64 memberId = reader.GetInt64(0);
    string name = Context.Guild.Users
        .Where(x => x.Id == memberId)
        .First()
        .Nickname != null 
            ? Context.Guild.Users.Where(x => x.Id == memberId).First().Nickname 
            : Context.Guild.Users.Where(x => x.Id == memberId).First().Username;
    Int64 votes = reader.GetInt64(2);
    GOTWVote.Add($@"{name} has received {votes} vote(s)");
