    public async Task<IActionResult> Create(MenuItemViewModel model)
    {
        if (ModelState.IsValid)
        {
            var menuItem = new MenuItem 
            {
                Name = model.Name,
                ...
            };
            var menuCategory = _Context.MenuCategories.Find(model.MenuCategory.MenuCategoryId);
            menuItem.MenuCategory = menuCategory;
            _Context.MenuItems.Add(menuItem);
            await _Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = menuItem.MenuCategory.MenuCategoryId });
        }
        return View(menuItem);
    }
