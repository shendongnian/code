    // api/menus/{menuId}/menuitems
    [HttpGet("{menuId}/getAllMenusItems")]
    public IActionResult GetAllMenuItemsByMenuId(int menuId)
    {            
        ....
    }
    // api/menus/{menuId}/menuitems?userId={userId}
    [HttpGet("{menuId}/getMenuItemsFiltered")]
    public IActionResult GetMenuItemsByMenuAndUser(int menuId, int userId)
    {
        ...
    }
