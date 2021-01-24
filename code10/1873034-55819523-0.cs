     public ActionResult Reorder(string searchString, int? page)
        {
            /// this has performance issues
            var supplies = db.ICS_Supplies.OrderByDescending(g => g.Supplies_ID).ToList();
             // problem here is you are checking for null, in a c# way and not linq
             var catalogs = supplies.Where(s => s.OnHand.HasValue && (searchString == null || s.Value <= int.Parse(searchString)));
            var pageNumber = page ?? 1;
            return View(catalogs.ToPagedList(pageNumber, 10));
    
        }
