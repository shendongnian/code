    private Dictionary<Guid, string> StyleMap = new Dictionary<Guid, string>
    {
        {Types.Standard, "Not normal" },
        {Types.Morning, "Not anormal" },
    };
    public string GetStyle(Guid stage)
    {
        string result;
        return StyleMap.TryGetValue(stage, out result) ? result : "Normal";
    }
