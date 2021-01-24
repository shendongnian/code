    // desc and loc
    if (!string.IsNullOrEmpty(searchValueToolDescription) && !string.IsNullOrEmpty(searchValueToolLocation)) {
        listTools.ItemsSource = container.Tools.Where(i => 
            i.ToolDescription.Contains(searchValueToolDescription) && 
            i.ToolLocation.Contains(searchValueToolLocation));
    } 
    // just desc
    else if (!string.IsNullOrEmpty(searchValueToolDescription)) {
        listTools.ItemsSource = container.Tools.Where(i => 
            i.ToolDescription.Contains(searchValueToolDescription)); 
    } 
    // just loc
    else if (!string.IsNullOrEmpty(searchValueToolLocation)) {
        listTools.ItemsSource = container.Tools.Where(i => 
            i.ToolLocation.Contains(searchValueToolLocation));
    }
