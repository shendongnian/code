    public ActionResult Index()
    {
        var rows = this.repository.GetAll();
        this.ViewData["total"] = rows.AsEnumerable().Select(o => o["NrOfRows"]).Select(o => int.Parse(o)).Sum();  
        return this.View(rows);
    }
