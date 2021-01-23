    private static object _facilRepoLock = new object();
    public static FacilityRepository FacilRepo
    {
        get
        {
            if (_facilRepo == null)
            {
                lock (_facilRepoLock)
                {
                    if (_facilRepo == null)
                    {
                        _facilRepo = new FacilityRepository(Authenticated.UserId);
                        if (Authenticated.FacKey.Length > 0)
                        {
                            foreach (var fac in _facilRepo)
                                fac.IsSelected = (fac.FacilityKey == Authenticated.FacKey);
                        }
                    }
                }
            }
            return _facilRepo;
        }
    }
    
    private static FacilityRepository _facilRepo;
