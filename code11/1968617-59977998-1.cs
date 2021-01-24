    protected override async Task OnInitializedAsync()
    {
        foreach (var p in myParams)
        {
            if (incomingParam.Equals(p,StringComparison.OrdinalIgnoreCase))
            {
                incomingParam = p;
            }
        }
    }
