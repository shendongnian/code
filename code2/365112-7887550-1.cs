    	Regex regxMatch = new Regex("(?<prefix>tcm:)(?<id>\\d+-\\d)(?<suffix>.)*",RegexOptions.Singleline|RegexOptions.Compiled);
       	string regxReplace = "${prefix}0-${id}";
    
    string GetPublicationID(string input) {
            return regxMatch.Replace(input, regxReplace);
    }
        string test = "tcm:481-191820-128";
        stirng result = GetPublicationID(test);
        //result: tcm:0-481-1
