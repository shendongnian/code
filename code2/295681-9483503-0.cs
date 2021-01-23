    private void MyTreeView_MouseUp(object sender, MouseEventArgs e)
    {
        // HACK: avoid to check root nodes (mr)
        var node = ((TreeView)sender).GetNodeAt(new Point(e.X, e.Y));
        if (node != null && node.Parent == null)
        BeginInvoke(new MouseEventHandler(TreeView_MouseUpAsync), sender, e);
    }
    private void TreeView_MouseUpAsync(object sender, MouseEventArgs e)
    {
        if (IsDisposed)
            return;
        var node = ((TreeView)sender).GetNodeAt(new Point(e.X, e.Y));
        node.Checked = false;
    }
