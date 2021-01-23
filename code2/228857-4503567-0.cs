    String test_string = "tesintg#$234524@#";
    if (System.Text.RegularExpressions.Regex.IsMatch(test_string, "^[a-zA-Z0-9\x20]+$"))
    {
      // Good-to-go
    }
