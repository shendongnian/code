    public LocationController(
        ICoreServicesDependencyGroup coreServicesDependencyGroup,
        ILocationDependencyGroup locationDependencyGroup)
    {
        _unitOfWork = coreServicesDependencyGroup.UnitOfWork;
        _loggingService = coreServicesDependencyGroup.LoggingService;
        _locationService = locationDependencyGroup.Service;
        _cachedLocationService = locationDependencyGroup.CachedService;
    }
