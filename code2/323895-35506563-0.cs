    private void listView_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Delete)
      {
        this.listView.Items.Remove(listView.SelectedItem);
      }
    }
