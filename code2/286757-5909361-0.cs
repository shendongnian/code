    public class MyTreeView : TreeView
    {
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Nodes.Add(new TreeNode("A Node"));
        }
    }
