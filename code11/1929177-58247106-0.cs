    static void Test()
    {
      var phraseSources = new List<A>();
      phraseSources.Add(new A { WatsonMeaning = "()" });
      phraseSources.Add(new A { WatsonMeaning = "text1" });
      phraseSources.Add(new A { WatsonMeaning = "()" });
      phraseSources.Add(new A { WatsonMeaning = "text2" });
      phraseSources.Add(new A { WatsonMeaning = "text3" });
      phraseSources.Where(x => x.WatsonMeaning == "()")
                   .ToList()
                   .ForEach(x => x.WatsonMeaning = "n/a");
      foreach ( var item in phraseSources )
        Console.WriteLine(item.WatsonMeaning);
    }
    class A
    {
      public string WatsonMeaning;
    }
