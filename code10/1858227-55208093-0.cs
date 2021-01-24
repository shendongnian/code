    // GET: CryptoCurrency
    public ActionResult Index()
    {
        var str = MakeAPICall();
        var viewModel = JsonConvert.Deserialize<YourViewModel>(str);
        return View(viewModel);
    }
