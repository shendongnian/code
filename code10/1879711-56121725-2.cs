    public string Message { get; set; }
    public AboutModel(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    private readonly IConfiguration _configuration = null;
    public void OnGet()
    {
        Message = "My key val = " + _configuration["AppSecret"];
    }
