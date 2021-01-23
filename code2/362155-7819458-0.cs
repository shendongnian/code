    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        // Main form
        private void MainFrm_Load(object sender, EventArgs e)
        {
            FormOrder frmO = new FormOrder();
            frmO.Tag=this;
            frmO.Show();
        }
        public void Refresh() 
        {
            // some action
        }
     }
    public partial class FormOrder : Form
    {
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
            Form  form = Tag as frmMain; // form now references the main form
            if (form != null)
            {
                form.Refresh();
            }
        }
    }
