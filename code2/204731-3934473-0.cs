    string[] temp = installerEmails.Split(',');
    var enumerator = temp.GetEnumerator();
    try
    {
      while(enumerator.MoveNext())
      {
        string email = (string)enumerator.Current;
        Console.WriteLine(email);
      }
    }
    finally
    {
      if(enumerator is IDisposable)
        ((IDisposable)enumerator).Dispose()
    }
