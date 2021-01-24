    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // Windows Load event
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            // Very Important Because by default it's null
            this.ContextMenu = new ContextMenu();
            // Making 3 sample Menu Item for ContextMenu
            MenuItem firstMenuItem = new MenuItem()
            {
                Header = "FirsMenu"
            };
            //1st of three way to give event to Controls. 
            // Giving click Event to firstMenuItem to seprate it's click behavior from Other Menu Items
            firstMenuItem.Click += (s, e) =>
            {
                // if Tag be Null on context Menu closing it's get that non of item selected so the click must be out side or lost focused
                this.ContextMenu.Tag = 1;
                MessageBox.Show("First Menu Clicked");
            };
            MenuItem secondMenuItem = new MenuItem()
            {
                Header = "SecondMenu"
            };
            //2nd of three way to give event to Controls. 
            // Giving click Event to secondMenuItem to seprate it's click behavior from Other Menu Items
            secondMenuItem.Click += delegate
            {
                // if Tag be Null on context Menu closing it's get that non of item selected so the click must be out side or lost focused
                this.ContextMenu.Tag = 1;
                MessageBox.Show("Second Menu Clicked");
            };
            MenuItem thirdMenuItem = new MenuItem()
            {
                Header = "ThirdMenu"
            };
            //3rd of three way to give event to Controls. 
            // Giving click Event to thirdMenuItem to seprate it's click behavior from Other Menu Items
            thirdMenuItem.Click += ThirdMenuOnClick;
            this.ContextMenu.Items.Add(firstMenuItem);
            this.ContextMenu.Items.Add(secondMenuItem);
            this.ContextMenu.Items.Add(thirdMenuItem);
            this.ContextMenu.Closed += ContextMenuOnClosed;
        }
        private void ThirdMenuOnClick(object sender, RoutedEventArgs e)
        {
            // if Tag be Null on context Menu closing it's get that non of item selected so the click must be out side or lost focused
            this.ContextMenu.Tag = 1;
            MessageBox.Show("Third Menu Clicked");
        }
        
        // Event for opening contextmenu on right mouse button click 
        private void MainWindow_OnMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.ContextMenu.IsOpen = true;
        }
        private void ContextMenuOnClosed(object sender, RoutedEventArgs e)
        {
            // if null means click must be out side or lost focused
            if (((ContextMenu)sender).Tag == null)
            {
                MessageBox.Show("You Clicked OutSide");
            }
            // very Importnt code , because it will reset the context menu tag logically
            ((ContextMenu)sender).Tag = null;
        }
    }
