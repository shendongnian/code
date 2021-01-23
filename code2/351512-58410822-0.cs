    TreeNode currentNode, targetNode;
    currentNode = TreeView1.SelectedNode;
    targetNode = currentNode.Parent;
    if (currentNode.Parent != null)
    {
        CopyedTreeNode = (TreeNode)targetNode.Clone();
        CopyedTreeNode02 = (TreeNode)currentNode.Clone();
        targetNode.Text = CopyedTreeNode02.Text;
        targetNode.Tag = CopyedTreeNode02.Tag;
        targetNode.ImageIndex = CopyedTreeNode02.ImageIndex;
        targetNode.SelectedImageIndex = CopyedTreeNode02.SelectedImageIndex;
        currentNode.Text = CopyedTreeNode.Text;
        currentNode.Tag = CopyedTreeNode.Tag;
        currentNode.ImageIndex = CopyedTreeNode.ImageIndex;
        currentNode.SelectedImageIndex = CopyedTreeNode.SelectedImageIndex;
        CopyedTreeNode.Remove();
        CopyedTreeNode02.Remove();
    }
