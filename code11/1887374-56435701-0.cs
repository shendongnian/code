    public class StaticMenuService : IMenuService
    {
        private List<MenuContainerItem> AdminMenuContainer;
        private List<MenuContainerItem> UserMenuContainer;
        public StaticMenuService(List<MenuContainerItem> adminMenus, List<MenuContainerItem> userMenus)
        {
            AdminMenuContainer = adminMenus;
            UserMenuContainer = userMenus;
        }
        public IList<MenuContainerItem> GetMenu(MenuType type)
        {
            if(type == MenuType.ADMIN)
            {
                return AdminMenuContainer.AsReadOnly();
            } 
            if(type == MenuType.USER)
            {
                return UserMenuContainer.AsReadOnly();
            }
            return new List<MenuContainerItem>().AsReadOnly();
        }
    }
