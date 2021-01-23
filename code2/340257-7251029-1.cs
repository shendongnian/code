    ContextMenu m = new ContextMenu();
    m.Items.Add("Item 1");
    m.Items.Add("Item 2");
    m.Items.Add("Item 3");
    m.PlacementTarget = sender as UIElement;
    m.Placement = System.Windows.Controls.Primitives.PlacementMode.Right;
    m.IsOpen = true;
