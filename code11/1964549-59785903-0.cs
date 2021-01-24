    public ExGatewayController(ILogger logger, IUtilityHelper utilityHelper)
    {
        _utilityHelper = utilityHelper ?? throw new ArgumentNullException(nameof(utilityHelper));;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
