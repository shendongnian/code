    private void btnMoveUp_Click(object sender, EventArgs e)
    {
      HashSet<KeyValuePair<int, object>> ItemsToMove = new HashSet<KeyValuePair<int, object>>();
      foreach (object o in lstMyListView.SelectedItems)
        ItemsToMove.Add(new KeyValuePair<int, object>(lstMyListView.Items.IndexOf(o), o));
      foreach (KeyValuePair<int, object> kvp in ItemsToMove)
      {
        if (kvp.Key > 0) // check if its the first item before moving
        {
          lstMyListView.Items.Remove(kvp.Value);
          lstMyListView.Items.Insert(kvp.Key - 1, kvp.Value);
        }
      }
    }
    private void btnMoveDown_Click(object sender, EventArgs e)
    {
      HashSet<KeyValuePair<int, object>> ItemsToMove = new HashSet<KeyValuePair<int, object>>();
      foreach (object o in lstMyListView.SelectedItems)
        ItemsToMove.Add(new KeyValuePair<int, object>(lstMyListView.Items.IndexOf(o), o));
      foreach (KeyValuePair<int, object> kvp in ItemsToMove)
      {
        if (kvp.Key < lstMyListView.Items.Count - 1) // check if its the last item before moving
        {
          lstMyListView.Items.Remove(kvp.Value);
          lstMyListView.Items.Insert(kvp.Key + 1, kvp.Value);
        }
      }
    }
