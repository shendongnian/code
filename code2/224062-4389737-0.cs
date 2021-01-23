    protected void OptionalNetworkCall(Action action)
    {
        if (useNetworkAccess)
        {
            using (new Core.NetworkAccess(username, password, domain))
            {
                action();
            }
        }
        else
        {
            action();
        }
    }
    protected void ValidateExportDirectoryExists()
    {
        OptionalNetworkCall(CheckExportDirectoryExists);
    }
