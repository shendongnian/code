    public class NavigationModel
    {
        public int currentMenuID { get; set; }   
        // used to determine the current displayed Menu to add
        // the "current" class to it. (to be set in the controller)
        public int currentMenuItemID { get; set; } 
        // used to determine the current displayed MenuItem to add
        // the "current" class to it. (to be set in the controller)
        public List<Menu> Menus { get; set; }
        public NavigationModel()
        {
            this.Menus = new List<Menu>();
            // Set Default Menu ( Menu 1 )
            this.currentMenuID = 1;
            // Set Default Menau Item ( None )
            this.currentMenuItemID = 0;
        }
    }
