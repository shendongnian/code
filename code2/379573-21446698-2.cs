    public override object InitializeLifetimeService() 
    {
        ILease lease = (ILease)base.InitializeLifetimeService();
        if(lease.CurrentState == LeaseState.Initial) {
            lease.InitialLeaseTime = TimeSpan.FromHours(24);
            lease.SponsorshipTimeout = TimeSpan.FromSeconds(30);
            lease.RenewOnCallTime = TimeSpan.FromHours(1);
        }
        return lease;
    }
    #region ISponsor Members
    [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.Infrastructure)]
    public TimeSpan Renewal(ILease lease) 
    {
        return TimeSpan.FromHours(12);
    }
    #endregion
