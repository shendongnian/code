    private void ListView1_MouseClick(object sender, MouseEventArgs e)
    {
      string mailtoLink = ListView1.SelectedItems[0].Item.ToString();
      System.Diagnostics.Process.Start(mailtoLink);
    }
