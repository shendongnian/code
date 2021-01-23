    public LocationController(
        IUnitOfWork unitOfWork,
        IAspNetMvcLoggingService loggingService, 
        ILocationService locationService, 
        ICachedLocationService cachedLocationService)
    {
        _unitOfWork = unitOfWork;
        _loggingService = loggingService;
        _locationService = locationService;
        _cachedLocationService = cachedLocationService;
    }
