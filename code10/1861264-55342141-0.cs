    private bool _isOpen = false;
    private void TestButton_Click(object sender, RoutedEventArgs e)
    {
        // This always prints false, even though the contextmenu is currently opened
        //System.Console.WriteLine(button.ContextMenu.IsOpen);
        if (sender is Button button)
        {
            if (_isOpen)
            {
                button.ContextMenu.IsOpen = false;
                _isOpen = false;
            }
            else
            {
                button.ContextMenu.Placement = PlacementMode.Bottom;
                button.ContextMenu.PlacementTarget = button;
                button.ContextMenu.StaysOpen = true;
                _isOpen = true;
                button.ContextMenu.IsOpen = _isOpen;
            }
        }
    }
