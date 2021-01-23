    public partial class FormOrder : Form
    {
        private frmMain _parent; // create a field that refers to the parent
        public FormOrder(frmMain parent) // mod the constructor
        {
            _parent = parent; // assign the ref of the parent
            InitializeComponent();
        }
        private void ShowForm()
        {
            // some action
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
                _parent.Refresh(); // make the call to parent
        }
    }
