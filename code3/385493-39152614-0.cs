    listbox.Items.Add( message );
    // this won't work as it will select all the items in your listbox as you add them
    //listbox.SelectedIndex = listbox.Items.Count - 1;
    // Deselect the previous "last" line    
    if ( listbox.Items.Count > 1 )
        listbox.SetSelected( listbox.Items.Count - 2, false );
    // Select the current last line
    listbox.SetSelected( listbox.Items.Count - 1, true );
    // Make sure the last line is visible on the screen, this will scroll
    // the window as you add items to it
    listbox.TopIndex = listbox.Items.Count - 1;
