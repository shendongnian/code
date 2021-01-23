        var usernames = new List<string>();
        Regex regex = new Regex(@"@[\S]+");
        MatchCollection matches = regex.Matches(strStatus);
        foreach (Match match in matches)
        {
            usernames.Add( match.ToString().Replace("@", "") );
        }
        // do longest first to avoid partial matches
        foreach (var username in usernames.OrderByDescending( n => n.Length ))
        {
            strStatus = strStatus.Replace( "@" + username, "www.domain.com/" + username );
        }
