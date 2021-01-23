    const string response =@"
        * FLAGS (\\Answered \\Flagged \\Draft \\Deleted \\Seen)
        * OK [PERMANENTFLAGS ()] Flags permitted.
        * OK [UIDVALIDITY 657136382] UIDs valid.
        * 3 EXISTS
        * 0 RECENT
        * EXISTS 4      <------------------- another occurence of the word
        * OK [UIDNEXT 4] Predicted next UID.
        * OK [READ-ONLY] INBOX selected. (Success)";
        string word = "EXISTS";
        string pattern =
            Regex.Escape(word) +  // the word to find followed by...
            @"
            \s+         (?# one ore more space characters followed by... )
            (?<num>\d+) (?# one or more digits. )
            
            |           (?# Or )
            
            (?<num>\d+) (?# one or more digits, then... )
            \s+         (?# one ore more space characters followed by... )"
            + Regex.Escape(word); // the word to find.
        foreach (Match match in Regex.Matches(response, pattern, RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace))
        {
            Console.WriteLine(match.Groups["num"]);
        }
