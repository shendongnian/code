    public partial class Form1 : Form
    {
        List<String> CheckedNodes = new List<String>();
        public Form1()
        {
            InitializeComponent();
        }
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                CheckedNodes.Add(e.Node.FullPath.ToString());
            }
            else
            {
                CheckedNodes.Remove(e.Node.FullPath.ToString());
            }
        }
    }
