    private void Label_Click(object sender, EventArgs e)
    {
      var nameLabel = ( sender as Label )?.Name ?? "Error";
      // ...
    }
    private void Label_Enter(object sender, EventArgs e)
    {
      ( sender as Label ).Cursor = Cursors.Hand;
    }
    private void Label_Leave(object sender, EventArgs e)
    {
      ( sender as Label ).Cursor = Cursors.Default;
    }
