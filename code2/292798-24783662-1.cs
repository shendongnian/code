    protected void HighlightSelectedLink(TreeNodeCollection nodes, string treeViewSelectedValue)
    {
        if (!string.IsNullOrEmpty(treeViewSelectedValue))
        {
            foreach (TreeNode tn in nodes)
            {
                if (tn.Value == treeViewSelectedValue)
                {
                    tn.Selected = true;
                }
                else
                {
                    tn.Selected = false;
                }
                HighlightSelectedLink(tn.ChildNodes, treeViewSelectedValue);
            }
        }
    }
    protected void tv_SelectedNodeChanged(object sender, EventArgs e)
    {
        string treeViewSelectedValue = tv.SelectedValue;
        if (treeViewSelectedValue.EndsWith(".aspx"))
        {
            Response.BufferOutput = true;
            Response.Redirect(tv.SelectedValue);
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        string treeViewSelectedValue = Request.AppRelativeCurrentExecutionFilePath;
        if (!string.IsNullOrEmpty(treeViewSelectedValue))
        {
            TreeNodeCollection nodes = tv.Nodes;
            HighlightSelectedLink(nodes, treeViewSelectedValue);
        }
    }
