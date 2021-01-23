    try
    {
        XDocument doc = XDocument.Parse(text);
    }
    catch(Exception _ex)
    {
         Console.WriteLine(_ex.Message);
    }
