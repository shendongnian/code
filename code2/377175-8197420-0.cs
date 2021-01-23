    public string GetTemplate(int pageId)
    {
        return db.PagesIndexes
                 .Where(p => p.Id == pageId)
                 .Select(p => p.Template)
                 .SingleOrDefault() ?? "_Layout";
    }
