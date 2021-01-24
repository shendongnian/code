     public App()
        {
            InitializeComponent();              
            Locator locator = new Locator();
            Container = locator.Container;
            .
            .
        }
    
        public static IContainer Container;
