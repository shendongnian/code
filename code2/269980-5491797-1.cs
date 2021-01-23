    public class adminMenuVM
    {
        private readonly IAdminMenuService menuService;
        public adminMenuVM(IAdminMenuService AdminMenuService)
        {
            this.menuService = AdminMenuService;
            menuItems = getMenuItems();
            menuCats = getMenuCats();
        }
    }
