    public partial class BackgroundWorkUINotification : Form
        {
            public event EventHandler CancelClicked;
    
        public BackgroundWorkUINotification()
        {
            InitializeComponent();
    
            // call code to animate progress bar..
            // probably in another BackgroundWorker that reports progress..            
    
            this.cancelButton.Click += HandleCancelButtonOnClick;
        }
    
    
        protected virtual void OnCancelClicked()
        {
            if (CancelClicked != null)
                this.CancelClicked(this, EventArgs.Empty);
        }
    
        private void HandleCancelButtonOnClick(Object sender, EventArgs e)
        {
            this.OnCancelClicked();
        }
    }
