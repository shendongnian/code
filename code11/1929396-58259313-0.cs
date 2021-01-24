`
    static void Test()
    {
      List<string> list = new List<string>();
      list.Add("Armor Lvl1(0:04)");
      list.Add("Loom(0:10)");
      list.Add("Balistics(4:42)");
      list.Add("Mail Armor(5:02)");
      list.Add("Ring(6:12)");
      list.Add("Fire Holes(8:44)");
      list.Add("Attack Lvl2(10:13)");
      list.Add("Defence Lvl1(12:33)");
      list.Add("Defence Lvl2(20:11)");
      list.Add("Attack(1:05)");
      list.Add("MoveUp(1:35)");
      list.Add("MoveDown(1:48)");
      list.Add("MoveLeft(2:15)");
      list.Add("MoveDown(2:24)");
      list.Add("MoveUp(2:50)");
      list.Add("MoveLeft(3:04)");
      list.Add("MoveUp(5:15)");
      list.Add("MoveLeft(7:30)");
      foreach ( var item in SortTheListByTime(list) )
        Console.WriteLine(item);
    }
`
`
    static List<string> SortTheListByTime(List<string> list)
    {
      var result = new List<string>();
      var items = new SortedDictionary<TimeSpan, string>();
      foreach ( string item in list )
      {
        int index;
        int posColon = item.IndexOf(':');
        if ( posColon == -1 ) continue;
        int posStart = -1;
        for ( index = posColon - 1; index >= 0; index-- )
          if (item[index] == '(')
          {
            posStart = index + 1;
            break;
          }
        if ( posStart == -1 ) continue;
        int posEnd = -1;
        for ( index = posColon + 1; index < item.Length; index++ )
          if ( item[index] == ')' )
          {
            posEnd = index - 1;
            break;
          }
        if ( posEnd == -1 ) continue;
        string strTime = item.Substring(posStart, item.Length - posEnd + 2);
        if ( TimeSpan.TryParse(strTime, out var time) )
          items.Add(time, item);
      }
      foreach ( var item in items )
        result.Add(item.Value);
      return result;
    }
`
