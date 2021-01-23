    private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label.Contains("|"))
            {
                if (WantAutofix())
                {
                }
                else
                {
                    e.CancelEdit = true;
                    BeginInvoke(new ActionDelegate(new NodeBeginEditAsync(e.Node).Execute));
                    return;
                }
            }
        }
    public class NodeBeginEditAsync
    {
        private readonly TreeNode _node;
        public NodeBeginEditAsync(TreeNode node)
        {
            _node = node;
        }
        public void Execute()
        {
            _node.BeginEdit();
        }
    }
    public delegate void ActionDelegate();
