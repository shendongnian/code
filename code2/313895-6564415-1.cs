    Regex reg = new Regex(@"^\\u([0-9A-Fa-f]{4})$");
    if( reg.IsMatch(s) )
    {
      char c = (char)int.Parse(s.Substring(2), NumberStyles.HexNumber);
    }
    else
    {
      // Error
    }
