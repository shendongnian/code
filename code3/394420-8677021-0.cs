    protected void TreeView1_TreeNodeDataBound(object sender, TreeNodeEventArgs e)
    {
        SiteMapNode node = (SiteMapNode)e.Node.DataItem;
        if(node.HasChildNodes ==false && e.Node.Depth ==1)
        {
            TreeView1.Nodes[0].ChildNodes.Remove(e.Node);
        }
    }
