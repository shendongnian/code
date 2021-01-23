    public partial class FormOrder : Form
    {
        public Form MainForm;
        public FormOrder()
        {
            InitializeComponent();
        }
        private void ShowForm()
        {
            // some action
        }
    
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (MainForm != null)
            {
                MainForm.Refresh();
            }
    
        }
    }
