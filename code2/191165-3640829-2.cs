    private static NavigationModel BuildNavigationMenu(User currentUser, string rootURL)
        {
            string loginURL = rootURL + "Account/LogOn";
            
            // Main Menu
            Menu MainMenu = new Menu(1, "Home");
            MainMenu.MenuItems.Add(new MenuItem(1, 1, "Welcome", rootURL, true));
            MainMenu.MenuItems.Add(new MenuItem(1, 2, "How It Works", rootURL + "Home/HowDoesItWork", true));
            // Work Menu
            Menu WorkMenu = new Menu(2, "Work");
            WorkMenu.MenuItems.Add(new MenuItem(2, 1, "Profile", rootURL + "User/Profile/" + currentUser.ID , true));
            WorkMenu.MenuItems.Add(new MenuItem(2, 2, "Customers", "#", true));
            
            // Add Menus To Navigation Model
            NavigationModel navigationMenu = new NavigationModel();
            navigationMenu.Menus.Add(MainMenu);
            navigationMenu.Menus.Add(HireMenu);
			
			return navigationMenu;
	}
