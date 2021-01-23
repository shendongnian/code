    private bool SelectParent = false;
    void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
    {
        this.treeView1.SelectedNode = e.Node.Parent;
        SelectParent = true;
    }
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (SelectParent)
            {
                this.treeView1.SelectedNode = this.treeView1.SelectedNode.Parent;
                SelectParent = false;
            }
           
        }
