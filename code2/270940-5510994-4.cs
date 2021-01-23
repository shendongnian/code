    public ActionResult CreateMenuItem(FormCollection fc)
    {
        MenuItem menuItem = CreateMenuItemFrom(fc);
        SaveMenuItem(menuItem);
        // tell this action method which view to render
        return View("MenuItemCreated", menuItem);
    }
    public ActionResult MenuItemCreated(MenuItem item)
    {
        return View(item);
    }
