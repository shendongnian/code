    var memberId = reader.GetInt64(0);
    // search for the user just a single time!
    var user = Context.Guild.Users.First(x => x.Id == memberId);
    // apply the rule to define the name string
    string name = @string.IsNullOrEmpty(user.Nickname) ? user.Nickname : user.Username;
    var votes = reader.GetInt64(2);
    GOTWVote.Add($@"{name} has received {votes} vote(s)");
