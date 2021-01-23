    static void Main(string[] args)
    {
      string a = "word:word:test:-1+234=567:test:test:";
      string[] tks = a.Split(':');
      Regex re = new Regex(@"^\b[A-Za-z0-9_]{4,}\b");
      var res = from x in tks
      where re.Matches(x).Count > 0
      select x + DecodeNO(tks.Count(y=>y.Equals(x)));
      foreach (var item in res)
      {
        Console.WriteLine(item);
      }
      Console.ReadLine();
    }
    
    private static string DecodeNO(int n)
    {
     switch (n)
     {
       case 1:
         return "_one";
       case 2:
         return "_two";
       case 3:
         return "_three";
      }
     return "";
    }
