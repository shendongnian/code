    private void listViewCards_KeyDown(object sender, KeyEventArgs e)
    {
        IList selectedListViewItems = listViewCards.SelectedItems;
        if (selectedListViewItems.Count > 1)
        {
            foreach(var node in ((ListViewItem)selectedListViewItems).Tag as XMLNode)
            {
                // Find your node in whatever type contains your xml
                // Do Some deleting or what have you.
            }
        }
    }
