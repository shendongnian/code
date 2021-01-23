    public partial class MainWindow
    {
        private Dispatcher uiDispatcher;
        
        public MainWindow()
        {
            InitializeComponents();
    
            // cache and then use in worker thread method
            this.uiDispatcher = uiDispatcher;
        }
    }
    
        
