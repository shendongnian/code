                string strStatus = "Hey @ronald and @tom where are we going this weekend";
            Regex regex = new Regex(@"@[\S]+");
            MatchCollection matches = regex.Matches(strStatus);
            foreach (Match match in matches)
            {
                string Username = match.ToString().Replace("@", "");
                strStatus = regex.Replace(strStatus, "www.domain.com/" + Username, 1);
            }
        }
