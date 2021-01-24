    class Program
    {
        static void Main(string[] args)
        {
            HeaderNavigationMenu navigationMenu = new HeaderNavigationMenu();
            navigationMenu.DropdownMenu2SelectOption3();
            // The following code is an example of undesired capability; 
            // prefer if Home class could only be 
            // used by HeaderNavigationMenu class
            //Home home = new Home();
        }
    }
    public class HeaderNavigationMenu
    {
        UsersMenu usersMenu;
        Home home;
        DropdownMenu2 dropdownMenu2;
        public HeaderNavigationMenu()
        {
            usersMenu = new UsersMenu();
            home = new Home();
            dropdownMenu2 = new DropdownMenu2();
        }
        public void DropdownMenu2SelectOption3()
        {
            dropdownMenu2.SelectOption3();
        }
        class UsersMenu
        {
        }
        class Home
        {
        }
        class DropdownMenu2
        {
            public void SelectOption3()
            {
            }
        }
    }
