    public partial class ChildForm : UserControl
    {
        public ChildForm ()
        {
            InitializeComponent();
        }
    
        public event EventHandler CloseTabRequested;
    
        protected virtual void OnCloseTabRequested(EventArgs e)
        {
             CloseTabRequested?.Invoke(this, EventArgs.Empty);
        }
        private void button1_Click(object sender, EventArgs e)
        {
             OnCloseTabRequested(EventArgs.Empty);
        }
    }
