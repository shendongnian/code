     if ((DataGridRow)sender.DataContext
            == dataGrid.SelectedItems.GetItemAt(dataGrid.SelectedItems.Count - 1))
     {
         var lastRowData = e.ClipboardRowContent;
         //// manipulate Clipboard to remove new line.
     }
