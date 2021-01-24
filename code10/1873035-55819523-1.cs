     public ActionResult Reorder(string searchString, int? page)
        {
            /check your string first
            if(searchString == null)
               searchString = "";
             
            ///from the below im guessing searchString is an int
            var int value = int.Parse(searchString);
            var supplies = db.ICS_Supplies.Where(x => x.OnHand != null 
                                    && searchString.Contians(x.FieldName) 
             .OrderByDescending(x => x.Supplies_ID)
             .ToList(); // to list forces a pull of the results
             
           //other stuff to work on
            var pageNumber = page ?? 1;
            return View(catalogs.ToPagedList(pageNumber, 10));
    
        }
