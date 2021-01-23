    // From the method you provided, with changes...
    public static List GetLists(int[] ids) // Could be List<int> or other =)
    {
        using (dbInstance db = new dbInstance())
        {
            return db.Lists.Where(m => !ids.Contains(m.ID));
        }
    }
