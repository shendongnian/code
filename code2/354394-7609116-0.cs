    Regex regex = new Regex(
          "\\(Item (?<part1>\\\".*\\\")\\s(?<part2>\\d+)\\s(?<part3>\\d"+
          "+)\\s(?<part4>\\d+)\\)",
        RegexOptions.Multiline | RegexOptions.Compiled
        );
    //Capture all Matches in the InputText
    MatchCollection ms = regex.Matches(InputText);
    
   
    //Get the names of all the named and numbered capture groups
    string[] GroupNames = regex.GetGroupNames();
    
    // Get the numbers of all the named and numbered capture groups
    int[] GroupNumbers = regex.GetGroupNumbers();
