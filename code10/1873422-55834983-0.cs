    private Form()
    {
    }
    public Form(string formId)
    {
        if (!Cache.ContainsKey(formId))
            Cache.Add(formId, new Form());
    }
