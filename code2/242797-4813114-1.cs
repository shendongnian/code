    string greetingTemplate = "Hello to {0}, our new {1} user(s) in last hour.";
    string separator = ",";
    //the two strings can be loaded from a config file
    var userNames = new[] { "user1", "user2", "user3", "user4" };
    int param1 = userNames.Length;
    if (param1 == 0) { /* No new users */ }
    string param0 = param1 == 1 ? userNames[0]
                         : string.Join(separator, userNames.Take(param1 - 1)) 
                                     + " and " + userNames.Last();
    string greeting = string.Format(greetingTemplate, param0, param1);
    
