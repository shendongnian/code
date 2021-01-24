    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
     
        private void LoadTrees()
        {
            // code to initialize the treeviews...
        }
     
        private void BtnLoadTrees_Click(object sender, EventArgs e)
        {
            LoadTrees();
        }
     
        private void BtnSync_Click(object sender, EventArgs e)
        {
            SyncronizeTrees();
        }
     
        private void SyncronizeTrees()
        {
            TreeSyncronizer.SyncTreeNodes(tv1.Nodes, tv2.Nodes);
            TreeSyncronizer.SyncTreeNodes(tv2.Nodes, tv1.Nodes);
        }
    }
    public class TreeSyncronizer
    {
        static public void SyncTreeNodes(TreeNodeCollection source, TreeNodeCollection target)
        {
            foreach (TreeNode node in source)
            {
                TreeNode theNode = SyncNode(node, target);
                SyncTreeNodes(node.Nodes, theNode.Nodes);
            }
        }
     
        static private TreeNode SyncNode(TreeNode node, TreeNodeCollection tv)
        {
            TreeNode fNode = FindNode(node, tv);
            if (fNode == null)
            {
                fNode = (TreeNode)node.Clone();
                tv.Insert(node.Index, fNode);
            }
            return fNode;
        }
     
        static private TreeNode FindNode(TreeNode nodeToFind, TreeNodeCollection tv)
        {
            TreeNode[] treeNodes = tv.Cast<TreeNode>().Where(r => r.Text == nodeToFind.Text).ToArray();
            foreach (TreeNode node in treeNodes)
            {
                if (node.Level == nodeToFind.Level)
                    return node;
            }
            return null;
        }
    }
