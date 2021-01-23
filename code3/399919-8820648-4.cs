    public partial class MyUserControl : UserControl
    {
        public MyForm ParentForm { get; set; }
        public MyUserControl()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ParentForm == null)
                return;
            ListBox listBox = (ParentForm.Controls["listBox1"] as ListBox);
            listBox.Items.Add("Test");
        }
    }
