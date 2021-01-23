    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            ChildForm childForm = new ChildForm();
            childForm.MdiParent = this;
            childForm.Show();
        }
    }
