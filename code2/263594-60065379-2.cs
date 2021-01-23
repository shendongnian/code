     List<ProductViewModel> lstProd = new List<ProductViewModel>();
     if (prods != null) 
     {
        // For setting the dates back to nulls, I'm looking for this value:
        // DateTime stdDate = DateTime.Parse("01/01/1800");
        
        foreach (var a in prods)
        {
            ProductViewModel o_prod = new ReportViewModel();
            o_prod.ID = a.ID;
            o_prod.Name = a.Name;
           // o_prod.ClosedDate = a.ClosedDate == stdDate ? null : a.ClosedDate;
            lstProd.Add(o_prod);
        }
    }
    return View(lstProd);  // use this in your View as:   @model IEnumerable<ProductViewModel>
