    public async Task<IActionResult> Index()
    {
        DashboardViewModel DatosParaMostrar = new DashboardViewModel();
         
        var result = (await ConsultaBD()).First();
        DatosParaMostrar.time = result.Values[0][0].ToString();
        DatosParaMostrar.valor = result.Values[0][1].ToString();
    
        return View(DatosParaMostrar);
    }
