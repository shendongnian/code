    treeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
    treeView.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeView_DrawNode);
    private void treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
    {
        if(NodeWithCheckBox(e.Node))
        {
           // draw entry with checkbox
           e.DrawDefault = false;
        }
        else
        {
           e.DrawDefault = true;
        }
    }
