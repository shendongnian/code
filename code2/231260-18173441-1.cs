    private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        if (e.Node == null) return;
        e.Node.Text = e.Node.Text.Substring(3, e.Node.Text.Length - 3);
        e.Node.BeginEdit();
    }
    private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
    {
        e.Node.Text = "S :" + e.Label;
        e.CancelEdit = true;
    }
