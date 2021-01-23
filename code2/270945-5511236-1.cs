    public ActionResult CreateMenuItem(FormCollection fc){
        MenuItem menuItem = CreateMenuItemFrom(fc);
        SaveMenuItem(menuItem); 
        TempData["menuitem"] = menuitem;
        return RedirectToAction("MenuItemCreated");
    }
    public ActionResult MenuItemCreated(){
        MenuItem menuItem = TempData["menuitem"] as MenuItem;
        // ....
    }
