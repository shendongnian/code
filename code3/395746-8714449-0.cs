    public class AControl : UserControl
    { 
        public event EventHandler<EventArgs> SetButtonClicked;
        
        public AControl ()
        {
            InitializeComponent();
            this.setButton.Click += (s,e) => OnSetButtonClicked;
        }
        protected virtual void OnSetButtonClicked()
        {
            var handler = SetButtonClicked;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
   
