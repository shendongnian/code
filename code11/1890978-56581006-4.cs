    public async Task<IActionResult> Index()
    {        
        var results = await ConsultaBD();
        IList<DashboardViewModel> model = results.Select(x => new DashboardViewModel {
             time = x.Values[0][0].ToString(),
             valor = x.Values[0][1].ToString()
        }).ToList();        
    
        return View(model);
    }
