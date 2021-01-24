    public ActionResult UpdateView(string Id)
    {
        DisplayViewModel dvm = new DisplayViewModel();
        ProductionLine pl = _productionLineService.Find(Id);
        dvm.ProdLine = new ProductionLineViewModel
        {
            Id = pl.Id,
            CreatedAt = pl.CreatedAt,
            Name = pl.Name,
            ActiveLine = pl.ActiveLine,
            ComputerName = pl.ComputerName,
            UPE = pl.UPE
       };
       return PartialView("~/Home/_Home.cshtml", dvm);
    }
