    <uc1:CustomControl Parameters="foo,bar" />
    [Category("Settings")]
    public string Parameters
    {
        set
        {
            var arr = String.Split(",", value).Select(p => p.Trim());
            if (parameters == null) parameters = new ListDictionary();
            foreach (string p in arr)
                parameters.Add(p);
            
        }
    }
