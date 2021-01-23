    string pattern = "\"([^\"]+)\"";
    value = Regex.Match(textToSearch, pattern).Value;
    
    string[] removalCharacters = {",",";"}; //or any other characters
    foreach (string character in removalCharacters)
    {
    	value = value.Replace(character, "");
    }
