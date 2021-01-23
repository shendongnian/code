        Regex spaceRegex = new Regex("\\s{2,}");
        //Only replace subsequent spaces, not all spaces. For example, 
        //"   " (three spaces) becomes " &nbsp;&nbsp;" (1 space, 2 non-breaking spaces).
        MatchEvaluator matchEvaluator = delegate(Match match)
        {
            StringBuilder spaceStringBuilder = new StringBuilder(" ");
            for (int i = 0; i < match.Value.Length - 1; i++)
            {
                spaceStringBuilder.Append("&nbsp;");
            }
            return spaceStringBuilder.ToString();
        };
        return spaceRegex.Replace(server.HtmlEncode(value), matchEvaluator);
    }
