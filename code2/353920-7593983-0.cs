    public Service1()
        {
            InitializeComponent();
        }
    
        protected override void OnStart(string[] args)
        {
            YourClass cl = new YourClass();
            cl.DoWhatYouNeed(...);       
        }
    
        protected override void OnStop()
        {
        }
