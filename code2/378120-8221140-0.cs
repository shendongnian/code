    static Regex inputParser = new Regex("(.{11})(.{12})(.{5})", RegexOptions.Compiled");
    
    foreach(Match m in inputParser.Matches(yourInput)) {
        BusinessEntity e = new BusinessEntity();
        e.Username = m.Groups(1).Value.TrimEnd(); // Remove spaces from the end; I take it that's what they'll be padded with
        e.City = m.Groups(2).Value.TrimEnd();
        e.ZipCode = m.Groups(3).Value;
        myListOfBusinessEntities.Add(e);
    }
