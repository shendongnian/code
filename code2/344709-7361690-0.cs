    public static string[] GetPopularSearches(int sectionID, int maxToFetch)
    {
        using (MainContext db = new MainContext())
        {
            var query = from c in db.tblSearches
                        where c.SectionID == sectionID && c.Featured
                        select c.Term;
            return query.Take(maxToFetch)
                        .ToArray();
        }
    }
