    var panes = GetPanes();
    int count = panes.Count;
    for(int i= count - 1; i>=0; i--)
    {
           pane = panes[i];
           pane.Clear();
           StateManager.Remove(pane);
           LayoutManager.Instance.RegisteredPanes.Remove(pane);
           //Items.Remove(pane);
           Items.RemoveAt(i);
    } 
