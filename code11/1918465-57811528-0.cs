    bool AltKeyPressed = false;
    private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
    {
      if (AltKeyPressed)
      {
        AltKeyPressed = false;
        if (e.SystemKey == Key.X) {
            e.SuppressKeyPress = true;
            e.Handled = true;
        }
       }
      if (e.SystemKey == Key.LeftAlt || e.SystemKey == Key.RightAlt)
      {
        AltKeyPressed = true;
      }
    }
