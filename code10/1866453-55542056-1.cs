    Int64 memberId = reader.GetInt64(0);
    var user = Context.Guild.Users.First(x => x.Id == memberId);
    string name = @string.IsNullOrEmpty(user.Nickname) ? user.Nickname : user.Username;
    Int64 votes = reader.GetInt64(2);
    GOTWVote.Add($@"{name} has received {votes} vote(s)");
