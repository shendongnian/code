    public partial class Page : UserControl 
    { 
        Analytics analytics;
        public Page() 
        { 
            InitializeComponent(); 
            CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);            
        }
        void CompositionTarget_Rendering(object sender, EventArgs e) 
        { 
            if (analytics == null) 
                analytics = new Analytics();
        }
    }
