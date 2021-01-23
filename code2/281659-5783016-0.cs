    using (var reader = new StringReader("<Results><Result>...</Result></Results>"))
    {
      var document = new XPathDocument();
      var navigator = document.CreateNavigator();
      var results = navigator.Select("//result");
    
      while (results.MoveNext())
      {
        Console.WriteLine("{0}:{1}", results.Current.Name, results.Current.Value);
      }
    }
