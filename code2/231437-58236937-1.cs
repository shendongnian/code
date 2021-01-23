    var bar= MyListView.GetVisibleScrollbars();
    while(bar== ScrollBars.Horizontal || bar== ScrollBars.Both)
    {
        progressPanels.SplitterDistance += 5;
        bar = MyListView.GetVisibleScrollbars();
    }
