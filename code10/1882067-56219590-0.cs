    public ActionResult HomeIndex()
    {
        HomeModel model = new HomeModel();
        var bestSalebooks = db.Books.Where(b => b.IsApproved).OrderBy(b => b.DisplayNumber).Select(b => (BookModel)(new
        {
            Id =  b.Id,
            Name = b.Name,
            Description = b.Description,
            Price = b.Price,
            DateAdded = b.DateAdded,
            CategoryId = b.CategoryId
    
        })).ToList();
        model.BestSales = bestSalebooks;            
        return View(model);
    }
