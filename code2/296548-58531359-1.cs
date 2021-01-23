    public void UncheckAllNodes()
    {
        foreach (TreeNode node in checkedNodes)
        {
            node.Checked = false;
        }
    }
