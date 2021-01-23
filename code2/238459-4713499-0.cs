	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			treeView1.Nodes.Add("1", "1");
			treeView1.Nodes.Add("2", "2");
			treeView1.Nodes[0].Nodes.Add("1-1", "1-1");
			TreeNode treeNode = treeView1.Nodes[0].Nodes.Add("1-2", "1-3");
			treeView1.SelectedNode = treeNode;
			MessageBox.Show(treeNode.IsSelected.ToString());
		}
	}
