    public IIdentity Identity { get; set; }
    public CoreIdentity GetCoreIdentity()
    {
        return (CoreIdentity)Identity;
    }
