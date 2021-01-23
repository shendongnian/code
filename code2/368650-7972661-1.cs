    var panes = GePanes();
    int count = pans.Count;
    for(int i= count - 1; i>=0; i--)
    {
           pane = panes[i];
           pane.Clear();
           StateManager.Remove(pane);
           LayoutManager.Instance.RegisteredPanes.Remove(pane);
           Items.Remove(pane);
    } 
