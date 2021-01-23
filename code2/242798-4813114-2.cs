    string template = "Hello to {NEWUSERS}, our new {COUNT} user(s) in last hour.";
    string separator = ",";
    //the two strings can be loaded from a config file
    var userNames = new[] { "user1", "user2", "user3", "user4" };
    int count = userNames.Length;
    if (count == 0) { /* No new users */ }
    string newUsers = count == 1 ? userNames[0]
                         : string.Join(separator, userNames.Take(count - 1)) 
                                     + " and " + userNames.Last();
    string greeting = template.Replace("{NEWUSERS}", newUsers)
                              .Replace("{COUNT}", count);
