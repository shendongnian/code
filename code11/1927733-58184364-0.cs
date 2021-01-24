    static public void Test()
    {
      var list = new string[]
      {
        "| title1 | title2 | title3 | title4 | title5 |",
        "| Word1 | Word2 | Word3 | Word4 | Word5 |"
      };
      int indexD1 = 0;
      string[][] result = null;
      Array.Resize(ref result, list.Length);
      foreach ( string item in list )
      {
        var str = item;
        str = str.TrimStart('|').TrimStart();
        str = str.TrimEnd('|').TrimEnd();
        str = str.Replace(" | ", "|");
        var items = str.Split('|');
        Array.Resize(ref result[indexD1], items.Length);
        int indexD2 = 0;
        foreach ( string part in items )
          result[indexD1][indexD2++] = part;
        indexD1++;
      }
      foreach ( var row in result )
      {
        foreach ( var str in row )
          Console.WriteLine(str);
        Console.WriteLine();
      }
    }
