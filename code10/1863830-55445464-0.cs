    var dictionary = new Dictionary<string, List<string>>();
    dictionary.Add("Lighter", new List<string>() { "Royal", "JSmith" });
    dictionary.Add("Darker", new List<string>() { "DCay", "Rebecca" });
    string userToMove = "DCay";
    string whereToMove = "Lighter";
    var list = dictionary.Values.SingleOrDefault(l => l.Contains(userToMove));  // list with user name
    list?.Remove(userToMove);  // remove user from current list if user in list
    dictionary[whereToMove].Add(userToMove); // add user to new list
