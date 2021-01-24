    public class AdminMenus 
    {
     
        public static implicit operator List<MenuContainerItem> (AdminMenus menus) 
        {
            MenuPageItem adminPageUsers = new MenuPageItem() {
                Id = "ADMIN_PAGE_1",
                PageName = "gestione utenti",
                Url = "/admin/users"
            };
            MenuPageItem adminPageRoles = new MenuPageItem() {
                Id = "ADMIN_PAGE_2",
                PageName = "gestione ruoli",
                Url = "/admin/roles"
            };
            MenuPageItem adminPageUserRoles = new MenuPageItem() {
                Id = "ADMIN_PAGE_3",
                PageName = "gestione utenti - ruoli",
                Url = "/admin/userRoles"
            };
            MenuContainerItem AdminBaseManagerPages = new MenuContainerItem() {
                Id = "ADMIN_CONTAINER",
                Icon = "preferences",
                ContainerName = "Gestione",
                Pages = new List<MenuPageItem>() { adminPageUsers, adminPageRoles, adminPageUserRoles }
            };
            return new List<MenuContainerItem>() { AdminBaseManagerPages };
        }
    } 
    public class UserMenus 
    {
        public static implicit operator List<MenuContainerItem> (UserMenus menus) 
        {
            return new List<MenuContainerItem>();
        }
    }
    
