    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
        MenuItem item = sender as MenuItem;
        ContextMenu cm = (ContextMenu)item.Parent; 
        Popup popup = (Popup)cm.Parent; 
    
        var finalGoal = popup.PlacementTarget as DataGrid; 
    }
