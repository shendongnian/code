    public static List<List> GetLists(List<int> listIDs)
    {
        using (dbInstance db = new dbInstance())
        {
            // Use this one to return List where IS NOT IN the provided listIDs
            return db.Lists.Where(x => !listIDs.Contains(x.ID)).ToList();
    
            // Or use this one to return List where IS IN the provided listIDs
            return db.Lists.Where(x => listIDs.Contains(x.ID)).ToList();
        }
    }
