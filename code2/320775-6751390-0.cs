    if (e.Action == TreeViewAction.ByMouse)
    {
        TabPage p = tabControl1.TabPages[e.Node.Tag]
        tabControl1.SelectedTab = p;
    }
