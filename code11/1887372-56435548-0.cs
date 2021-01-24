    public abstract class MenuService
    {
        public MenuService(List<MenuContainerItem>() container)
        {
            // do shared container setup 
        }
    }
    public class AdminMenuService : MenuService
    {
        public AdminMenuService(List<MenuContainerItem>() container) : base(container)
        {
        }
    }
