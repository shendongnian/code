    if (nodeToRemove.Nodes.Count > 0) {
    List<TreeNode> childNodes = new List<TreeNode>();
    foreach (TreeNode n in nodeToRemove.Nodes) {
       childNodes.Add(n);
    }
    if ((nodeToRemove.Parent != null)) {
       nodeToRemove.Parent.Nodes.AddRange(childNodes.ToArray());
       } else {
         nodeToRemove.TreeView.Nodes.AddRange(childNodes.ToArray());
        }
       }
    nodeToRemove.Remove();
