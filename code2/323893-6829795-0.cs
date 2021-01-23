    ListView_KeyPress(object sender, KeyPressEventArgs e)
    {
       if (e.KeyCode == Keys.Delete)
        {
            foreach (ListViewItem listViewItem in MyListView.SelectedItems)
           {
              listViewItem.Remove();
           }
        }
    }
    
