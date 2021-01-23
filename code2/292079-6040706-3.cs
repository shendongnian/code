    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            InitializeComponent();
        }
        private void Child_FormClosed(object sender, FormClosedEventArgs e)
        {
            ParentForm parentForm = (ParentForm)this.MdiParent;
            parentForm.panel1.Visible = true;
        }
    }
