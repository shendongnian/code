    public ActionResult MenuItemCreated(int id)
    {
        MenuItem item = someService.GetMenuItemById(id);
        return View(item);
    }
