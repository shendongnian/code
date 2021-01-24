    // some crappy input string with upper and lower case and spaces only sometimes before the game name.
    string inputString = "Name: game1, StatusName Name: game2, Bla bla Name: game1, Some more Text StatusName Name:game3"; ;
    // Define a pattern (explaination on the bottom of this answer)
    Regex gameName = new Regex("Name:[ ]?(?<GameName>[^,]*),", RegexOptions.IgnoreCase);
    // Create a "list" which will contain the names in the end
    HashSet<string> GameNames = new HashSet<string>();
    // Loop through all substrings which match our pattern
    foreach (Match m in gameName.Matches(inputString))
    {
        string name = m.Groups["GameName"].Value;
        Console.WriteLine("Found: " + name); // what did we match?
        if (!GameNames.Contains(name)) // add game to list if not contained
            GameNames.Add(name);
    }
    // Let's see what we got
    Console.WriteLine("All Games: " + string.Join(", ", GameNames));
