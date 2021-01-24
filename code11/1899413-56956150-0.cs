    [Route("Listings/details/{id}/{name:slugify}", Name = "Details")]
    public IActionResult Details(int id, string name)
    {
        return RedirectToRoutePermanent("NewDetails", new { id, name });
    }
    
