    public partial class ChildForm : UserControl
    {
        public ChildForm ()
        {
            InitializeComponent();
        }
    
        public event EventHandler CloseTabRequested;
    
        private void button1_Click(object sender, EventArgs e)
        {
             CloseTabRequested?.Invoke(this, EventArgs.Empty);
        }
    }
