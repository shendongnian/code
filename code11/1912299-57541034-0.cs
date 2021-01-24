        public your_constructor()
        {
            InitializeComponent();
            /*
             Your codes here ...
             */
            test.PreviewMouseRightButtonUp += delegate
            {
                System.Windows.Controls.ContextMenu contextMenu = new System.Windows.Controls.ContextMenu();
                System.Windows.Controls.MenuItem modify_menu = new System.Windows.Controls.MenuItem();
                modify_menu.Header = "Modify";
                modify_menu.Click += delegate
                {
                    //your codes here once the user click on "Modify" ... 
                };
            };
            
        }
