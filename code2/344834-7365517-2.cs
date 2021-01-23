    public static string[] getSearchSuggestions(int SectionID, string Query)
    {
        string[] Suggestions;
        string[] Words = Query.Split(' ');
        using (MainContext db = new MainContext())
        {
            string[] all = (from c in db.tblSearches
                        where c.SectionID == SectionID
                        select c.Term).ToArray();
            Suggestions = (from a in all
                           from w in Words
                           where a.Contains(w)
                           select a).Distinct().ToArray();
        }
        return Suggestions;
    }
