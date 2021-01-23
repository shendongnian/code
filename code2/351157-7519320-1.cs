    private void TextBox_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Enter)
      {
        // Locate current item.
        int current = lstBoxList.Items.IndexOf(sender);
        
        // Find the next item, or give up if we are at the end.
        int next = current + 1;
        if (next > lstBoxList.Items.Count - 1) { return; }
    
        // Focus the item.
        (lstBoxList.Items[next] as TextBox).Focus();
      }
    }
