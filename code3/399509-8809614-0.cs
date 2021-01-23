    [HttpPost]
    [ValidateInput(false)]
    public ActionResult Create(BooksItem booksitem)
    {
        try
        {
            using (var db = new Booksforsale())
            {
                db.BooksItem.Add(booksitem);
                db.SaveChanges();
            }
            TempData["message"] = "The item has been saved";
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }
