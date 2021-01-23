    protected override void OnKeyPress(KeyPressEventArgs e)
    {
      base.OnKeyPress(e);
      if (char.IsLetter(e.KeyChar))
      {
        // char is letter
      }
      else if (char.IsDigit(e.KeyChar))
      {
        // char is digit
      }
      else
      {
        // char is neither letter or digit.
        // there are more methods you can use to determine the
        // type of char, e.g. char.IsSymbol
      }
    }
