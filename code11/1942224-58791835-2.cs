    SystemEvents.SessionEnding += SessionEnding;
    private void SessionEnding(object sender, SessionEndingEventArgs e)
    {
      IsSessionEnding = true;
      Close();
    }
