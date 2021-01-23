    Regex reg = new Regex(@"^\\u([0-9A-Fa-f]{4})$");
    if( reg.IsMatch(s) )
    {
      // parse s
    }
    else
    {
      // Error
    }
