    public ActionResult Reorder(string searchString, int? page)
    {   
    int convertInt = 0;
    
    var catalogs = db.ICS_Supplies
            .OrderByDescending(g => g.Supplies_ID)
            .ToList();
    
    if (Int32.TryParse(searchString, out convertInt))
    {
       catalogs = supplies
                .Where(s => 
                    s.OnHand.HasValue &&
                    s.OnHand.Value <= convertInt);
    }
     var pageNumber = page ?? 1;
    
     return View(catalogs.ToPagedList(pageNumber, 10));
    }
