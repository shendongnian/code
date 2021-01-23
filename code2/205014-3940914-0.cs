    String sampleInput = "\"John Smith\" Pocahontas Bambi \"Jane Doe\" Aladin";
    //Create regex pattern
    Regex regex = new Regex("\"([^\".]+)\"");
    List<string> searches = new List<string>();
    //Loop through all matches from regex
    foreach (Match match in regex.Matches(sampleInput))
    {
        //add the match value for the 2nd group to the list
        //(1st group is the entire match)
        //(2nd group is the first parenthesis group in the defined regex pattern
        //   which in this case is the text inside the quotes)
        searches.Add(match.Groups[1].Value);
    }
    //remove the matches from the input
    sampleInput = regex.Replace(sampleInput, String.Empty);
    //split the remaining input and add the result to our searches list
    searches.AddRange(sampleInput.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries));
