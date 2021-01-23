    string value = ("{\"ID\":\"([A-Za-z0-9_., ]+)\",");
    MatchCollection matches = Regex.Matches(textt, @value);
    for (int i = 0; i < matches.Count; i++)
    {
        Response.Write(matches[i].ToString());
    }
