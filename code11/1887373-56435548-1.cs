    var adminMenuService = new AdminMenuService()
    var userMenuService = new UserMenuService()
    [TestCase(adminMenuService)]
    [TestCase(userMenuService)]
    public void IMenuServiceReturnsAlwaysAList(MenuService menuService)
    {
        menuService.getMenu() // test what you expect to happen in all MenuServices
    }
