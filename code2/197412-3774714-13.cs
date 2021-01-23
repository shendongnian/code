    public ViewResult List(int id)
    {
        var model = new BookModel 
        {
            AuthorIds = service.GetAuthorIDs(id)
        };
        return View(model);
    }
