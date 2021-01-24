    [Route("")]
    public async Task<IActionResult> Index()
    {
        return await WrappedMethod(null);
    }
    
    [Route("tag/{pageNumber}")]
    public async Task<IActionResult> Index(int pageNumber)
    {
        return await WrappedMethod(pageNumber);
    }
    [Route("tag/{tagSlug}/{pageNumber}")]
    public async Task<IActionResult> Index(string tagSlug, int? pageNumber)
    {
        return await WrappedMethod(pageNumber, tagSlug);
    }
    private async Task<IActionResult> WrappedMethod(int? pageNumber, string tagSlug = null, string searchTerm = null)
    {
        var model = await repoPm_.GetPage(pageNumber, tagSlug, searchTerm);
        return View(model);
    }
