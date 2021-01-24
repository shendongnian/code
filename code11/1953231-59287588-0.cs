    [HttpGet("{menuId}/menuitems")]
    public IActionResult GetMenuItems(int menuId, int userId) =>
        userId == 0 ? GetMenuItemsByMenuId(menuId) : GetMenuItemsByUserId(menuId, userId);
    private IActionResult GetMenuItemsByMenuId(int menuId)
    {
        ...
    }
    private IActionResult GetMenuItemsByUserId(int menuId, int userId)
    {
        ...
    }
