    public IActionResult Index()
    {
        DashboardViewModel DatosParaMostrar = new DashboardViewModel();
        
        foreach(var data in ConsultaBD().Result){
            DatosParaMostrar.time = data.Values[0].ToString();
            DatosParaMostrar.valor = data.Values[1].ToString();
            DatosParaMostrar.lstDatosParaMostrar.Add(DatosParaMostrar);
        }        
        return View(DatosParaMostrar);
    }
