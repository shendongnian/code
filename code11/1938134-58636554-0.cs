    private readonly IJSRuntime _jsRuntime;
    public IndexModel(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
    [BindProperty]
    public string clientToken { get; set; }
    public void OnGet()
    {
        // Create gateway
        var gateway = new BraintreeGateway
        {
            Environment = Braintree.Environment.SANDBOX,
            MerchantId = "xxxxxxx",
            PublicKey = "xxxxxxx",
            PrivateKey = "xxxxxxx"
        };
        clientToken = gateway.ClientToken.Generate();
        JSRuntimeExtensions.InvokeVoidAsync(_jsRuntime, "configureBraintreeClient", clientToken);
    }
