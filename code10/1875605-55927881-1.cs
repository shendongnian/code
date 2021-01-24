    public ActionResult Index(string searchString, string SType, int? page, string YourRadioButton)
    {
         var supplies = db.ICS_Supplies.Where(s => s.InvType.Contains(YourRadioButton ?? string.Empty));
         // Add SearchBox Filter
         supplies = supplies.Where(s =>  s.ItemDescription.Contains(searchString ?? string.Empty));
         supplies = supplies.OrderBy(g => g.ItemDescription)
         // Add paging to the search results
         var pageNumber = page ?? 1;
         return View(supplies.ToPagedList(pageNumber, 10));
    }
