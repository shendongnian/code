    public ActionResult Index(string searchString, string SType, int? page, string YourRadioButton)
    {
         var supplies = db.ICS_Supplies;
         if (!String.IsNullOrWhiteSpace(YourRadioButton))
         {
             supplies = supplies.Where(s => s.InvType.Contains(YourRadioButton));
         }
         if (!String.IsNullOrWhiteSpace(searchString))
         {
             supplies = supplies.Where(s =>  s.ItemDescription.Contains(searchString));
         }
         supplies = supplies.OrderBy(g => g.ItemDescription)
         // Add paging to the search results
         var pageNumber = page ?? 1;
         return View(supplies.ToPagedList(pageNumber, 10));
    }
