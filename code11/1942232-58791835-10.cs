    private bool IsSessionEnding;
    private void SessionEnding(object sender, SessionEndingEventArgs e)
    {
      IsSessionEnding = true;
      Close();
    }
