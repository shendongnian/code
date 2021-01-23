    private void Ribbon_PreviewKeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Tab)
      {
        
        if (ribbon.SelectedIndex ==  ribbon.Items.Count -1)
        {
          ribbon.SelectedIndex = 0;
        }
        else
        {
          ribbon.SelectedIndex++;
        }
      }
      e.Handled = true;
    }
