    using (var reader = new StringReader("<Results><Result>...</Result></Results>"))
    {
      var document = XDocument.Load(reader);
      var results = document.Elements("result");
    
      foreach (var item in results)
      {
        Console.WriteLine("{0}:{1}", item.Name, item.Value);
      }
    }
