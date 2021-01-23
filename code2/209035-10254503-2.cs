    public void TreeView1_OnClick(Object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(
            Page,
            Page.GetType(),
            "HighlightSelectedNode",
            "HighlightSelectedNode();",
            true
        );
    }
