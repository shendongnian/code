        private ObservableCollection<MenuItemVM> menuItems = new ObservableCollection<MenuItemVM>(
            new List<MenuItemVM>
            {
                new MenuItemVM{ Header="File", SubItems= new ObservableCollection<MenuItemVM>( new List<MenuItemVM>
                {
                    new MenuItemVM{ Header="Open"},
                    new MenuItemVM{ Header="Save"}
                })
                }
            }
            
            );
