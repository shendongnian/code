    private Form()
    {
    }
    public static Form BuildForm(string formId)
    {
        if (!Cache.ContainsKey(formId))
        {
            Cache.Add(formId, new Form());
        }
        return Cache[formId];
    }
