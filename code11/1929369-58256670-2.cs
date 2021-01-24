`
    static void Test()
    {
      var list = new List<int>();
      list.Add(4);
      list.Add(25);
      list.Add(26);
      list.Add(27);
      list.Add(38);
      list.Add(51);
      list.Add(52);
      list.Add(53);
      list.Add(75);
`
`
      var result = new List<int>();
      int count = list.Count;
      bool passover;
      if ( count > 0 )
        for ( int index = 0; index < count; )
        {
          passover = false;
          if ( index < count - 3 )
          {
            int v1 = list[index];
            int v2 = list[index + 1];
            int v3 = list[index + 2];
            if ( v3 == v2 + 1 && v2 == v1 + 1 )
              passover = true;
          }
          if ( passover )
          {
            result.Add(list[index + 2]);
            index += 3;
          }
          else
          {
            result.Add(list[index]);
            index++;
          }
        }
`
`
      foreach ( var item in result )
        Console.WriteLine(item);
    }
`
Output:
`
4
27
38
53
75
`
