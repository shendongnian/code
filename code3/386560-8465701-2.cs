    public partial class MainWindow
    {
        private Dispatcher uiDispatcher;
        
        public MainWindow()
        {
            InitializeComponents();
    
            // cache and then use in worker thread method
            this.uiDispatcher = uiDispatcher;
        }
        public void MyLongCalculations(object myvalues)
        {
            ParameterObject values = (ParameterObject)myvalues;
            this.uiDispatcher.BeginInvoke(/*a calculations delegate*/);
        }
    }
    
        
