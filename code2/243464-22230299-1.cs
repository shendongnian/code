    private void MyForm_Load(object sender, EventArgs e)
    {
         this.treeview1.DrawMode = TreeViewDrawMode.OwnerDrawText;
         this.treeview1.DrawNode += new DrawTreeNodeEventHandler(arbolDependencias_DrawNode);
    }
    
    void treeview1_DrawNode(object sender, DrawTreeNodeEventArgs e)
    {
        if (e.Node.Level == 1) e.Node.HideCheckBox();
        e.DrawDefault = true;
    }
