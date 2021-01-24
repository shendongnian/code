    private readonly ILogger<HomeController> _logger;
    private OktaConfig oktaConfig;
    public HomeController(ILogger<HomeController> logger , OktaConfig oktaConfig)
    {
        this.oktaConfig = oktaConfig;
        _logger = logger;
    }
    public IActionResult Index()
    {
        return Ok(oktaConfig.RedirectUrl);
    }
