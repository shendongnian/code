    public IManager GetInvokeType(string id)
    {
        switch (id.ToUpperInvariant())
        {
            case "CM":
                return new BCMSDashboardManager();
            default:
                return new SIPManager();
        }
    }
 
