    private async Task RefreshSensorView()
    {
        await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
            AxiseslistViewStackPanel.Children.Clear();
            foreach (var axis in axisesCollection)
            {
                var axisListView = new ListView
                {
                    Header = "Axis: " + axis.AxisNumber,
                    SelectionMode = ListViewSelectionMode.Multiple,
                    ShowsScrollingPlaceholders = true,
                };
                axisListView.ItemsSource = axis.inUseAntennaList;
                AxiseslistViewStackPanel.Children.Add(axisListView);
            }
        });
    }
