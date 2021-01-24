    protected override void OnInitialized()
    {
        base.OnInitialized();
        foreach (var p in myParams)
        {
            if (String.Equals(p, incomingParam, StringComparison.OrdinalIgnoreCase))
            {
                incomingParam = p;
            }
        }
