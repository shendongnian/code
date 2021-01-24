        private static void RunApplication(Container container)
        {
            try
            {
                var mainWindow = container.GetInstance<MainWindow>();
                var app = new App();
                app.InitializeComponent();
                app.Run(mainWindow);
            }
            catch (Exception ex)
            {
                //Log the exception and exit
                Debug.WriteLine(ex.Message);
            }
        }
