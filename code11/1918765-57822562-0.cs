    private void tvEinfuegen_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        TreeViewHitTestInfo info = tvEinfuegen.HitTest(e.Location);    
        if (info.Location == TreeViewHitTestLocations.Label)
        {
            if (e.Node!= null)
                e.Node.Nodes.Add("test");
        }
    }
