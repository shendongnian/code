    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool ShowMessageBox()
        {
            return MessageBox.Show("Change to first item instead?", "test", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }
        private void listView1_Click(object sender, EventArgs e)
        {
            if (ShowMessageBox())
                listView1.TopItem.Selected = true;
                label1.Text += "item selected   ";
        }
    }
