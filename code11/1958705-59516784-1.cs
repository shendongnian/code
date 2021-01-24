           //Draw the left column
            //Add a vertical scrollbar
            ScrollViewer scrollBar = new ScrollViewer();
            scrollBar.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            Grid.SetRow(scrollBar, 1);
            Grid.SetColumn(scrollBar, 0);
            statsDrawGrid.Children.Add(scrollBar);
            //Draw the container/border
            Border leftPanelBorder = new Border();
            Grid.SetColumn(leftPanelBorder, 0);
            Grid.SetRow(leftPanelBorder, 1);
            scrollBar.Content = leftPanelBorder;
            Grid.SetRow(leftStackPanel, 1);
            Grid.SetColumn(leftStackPanel, 0);
            leftPanelBorder.Child = leftStackPanel;
