    private void treeViewOptions_AfterSelect(object sender, TreeViewEventArgs e)
    {
        foreach (Control ctl in ControlPanel.Controls) ctl.Dispose();
        ControlPanel.Controls.Clear();
        switch (treeViewOptions.SelectedNode.Name)
        {
            case "NodeConnection":
                ControlPanel.Controls.Add(_connections);
                break;
            case "NodeNotifications":
                ControlPanel.Controls.Add(_notifications);
                break;
            case "NodeProxy":
                ControlPanel.Controls.Add(_proxy);
                break;
        }
    }
