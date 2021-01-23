    Button_Click() {
        CheckUncheckTreeNode(YourTreeView.Nodes, false);
    }
    private void CheckUncheckTreeNode(TreeNodeCollection trNodeCollection, bool isCheck) {
        foreach (TreeNode trNode in trNodeCollection) {
            trNode.Checked = isCheck;
            if (trNode.ChildNodes.Count > 0)
                CheckUncheckTreeNode(trNode.ChildNodes, isCheck);
        }
    }
