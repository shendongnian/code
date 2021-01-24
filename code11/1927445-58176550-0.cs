    static void Main(string[] args)
    {
        string text =
            "This is an example of the text to parse through, it has the title of role1. We want to extract data points like Party1 which is a role2 followed by Party2 which is a role3. Finally, we want to find Party3. This party is also known as role4. We want to display each party with its respective role";
        string[] parties = {"Party1", "Party2", "Party3"};
        string[] roles = {"role1", "role2", "role3", "role4"};
        List<string> results = new List<string>();
        int index = 0;
        foreach (var party in parties)
        {
            index = text.IndexOf(party, index);
            if (index <= -1) continue;
            var r = roles
                .Select(role => new {Role = role, Index = text.IndexOf(role, index)})
                .Where(i => i.Index > -1)
                .OrderBy(i => i.Index)
                .First();
            results.Add(r != null ? $"{party} = {r.Role}" : $"{party} = N/A");
            index = r?.Index ?? index;
        }
        var result = string.Join(" \n ", results);
        GetKeyFromUser("\n\nDone! Press any key to exit...");
    }
