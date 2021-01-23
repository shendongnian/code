    public override Object InitializeLifetimeService()
    {
      ILease lease = (ILease)base.InitializeLifetimeService();
      if (lease.CurrentState == LeaseState.Initial)
      {
         lease.InitialLeaseTime = TimeSpan.FromMinutes(100);
         lease.SponsorshipTimeout = TimeSpan.FromMinutes(100);
         lease.RenewOnCallTime = TimeSpan.FromSeconds(100);
      }
      return lease;
    }
