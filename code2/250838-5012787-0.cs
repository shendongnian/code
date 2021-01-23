    private void trvAvailableFiles_AfterCheck(object sender, TreeViewEventArgs e)
    {
        EnableEvents(false);
        trvAvailableFiles.BeginUpdate();
        var nodePath = e.Node.Tag.ToString();
        bool isChecked = e.Node.Checked;
        e.Node.Nodes.Clear();
        try
        {
            _fileTreeLogic.GetChildNodes(e.Node, true);
            e.Node.ExpandAll();
            SetChildrenCheckState(e.Node, isChecked);
        }
        finally
        {
            trvAvailableFiles.EndUpdate();
        }
        EnableEvents(true);
    }
    private void EnableEvents(bool bEnable)
    {
        if(bEnable)
            cbWhatever.OnChecked += EventHandler;
        else
            cbWhatever.OnChecked -= EventHandler;
    }
