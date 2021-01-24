    public void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
        string formName = treeView1.SelectedNode.Name.ToString();
        string namespaceName = treeView1.SelectedNode.Tag.ToString();
        var newForm = new FORMNAME();
        newForm.ShowDialog();
    }
