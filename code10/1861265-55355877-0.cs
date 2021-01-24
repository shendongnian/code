    private DependencyPropertyDescriptor _dpd;
    private DateTime _closeTime;
    private void TestButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button)
        {
            button.ContextMenu.Placement = PlacementMode.Bottom;
            button.ContextMenu.PlacementTarget = button;
            button.ContextMenu.IsOpen = !button.ContextMenu.IsOpen && DateTime.UtcNow.Subtract(_closeTime).TotalMilliseconds > 250;
            if (_dpd == null)
            {
                _dpd = DependencyPropertyDescriptor.FromProperty(ContextMenu.IsOpenProperty, typeof(ContextMenu));
                _dpd.AddValueChanged(button.ContextMenu, OnContextMenuClosed);
            }
        }
    }
    private void OnContextMenuClosed(object sender, EventArgs e) => _closeTime = DateTime.UtcNow;
