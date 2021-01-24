    Grid.SetRow(leftPanelBorder, 1);
    statsDrawGrid.Children.Add(leftPanelBorder);
    //Add a vertical scrollbar
    ScrollViewer scrollBar = new ScrollViewer();
    scrollBar.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
    Grid.SetRow(scrollBar, 1);
    Grid.SetColumn(scrollBar, 0);
    statsDrawGrid.Children.Add(scrollBar);
    Grid.SetRow(leftStackPanel, 1);
    Grid.SetColumn(leftStackPanel, 0);
    leftPanelBorder.Child = leftStackPanel;
    //Draw the reservoir list
    InitializeTheReservoirs();
    DrawTheReservoirList(leftStackPanel, (string)byNameMenu.Header);
    statsDrawGrid.ShowGridLines = true;
    statsWindow.Content = statsDrawGrid;
    statsWindow.Show();
