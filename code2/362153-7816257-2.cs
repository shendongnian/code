    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        // Main form
        private void MainFrm_Load(object sender, EventArgs e)
        {
            FormOrder frmO = new FormOrder(this); // pass a ref of self
            frmO.Show();
        }
        public void Refresh() 
        {
            // some action
        }
     }
