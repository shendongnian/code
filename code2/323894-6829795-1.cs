    private void listView1_KeyDown(object sender, KeyEventArgs e)
    {
        if (Keys.Delete == e.KeyCode)
        {
            foreach (ListViewItem listViewItem in ((ListView)sender).SelectedItems)
            {
                listViewItem.Remove();
            }
        }
    }
