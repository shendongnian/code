    [HttpPost]
    public ActionResult Search(SearchView search)
    {
        return RedirectToAction("Index", "Pricing", new { exactNameOfSearchViewParameter = search });
    }
