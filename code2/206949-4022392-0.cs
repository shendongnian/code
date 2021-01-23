        public static CommandBarControl GetCustomMenu(DTE2 applicationObject)
        {
            //Find the MenuBar command bar, which is the top-level command bar holding all the main menu items
            CommandBar menuBarCommandBar = ((CommandBars)applicationObject.CommandBars)["MenuBar"];
            //Find the Tools command bar on the MenuBar command bar as we want to add it before it
            CommandBarControl toolsControl = menuBarCommandBar.Controls["Tools"];
            CommandBarControl myMenu;
            try
            {
                // Get the menu bar if it already exists
                myMenu = menuBarCommandBar.Controls["My Menu"];
            }
            catch (Exception)
            {
                // Doesnt exist so crate a new one.
                myMenu = menuBarCommandBar.Controls.Add(Type: MsoControlType.msoControlPopup, Id: 1234567890, Before: toolsControl.Index - 1);
                myMenu.Caption = "My Menu"];;
            }
            return myMenu;
        }
