    var A = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    var B = new List<string>() { "A", "B", "C", "D" }; 
    var C = new List<string>() { "!", "?", "-"};
    var lists = new List<List<string>>() { A, B, C };
    int count = 0;
    foreach ( var list in lists )
      count = Math.Max(count, list.Count);
    var result = new List<List<string>>();
    for ( int index = 0; index < count; index++ )
    {
      var item = new List<string>();
      result.Add(item);
      foreach ( var list in lists )
        item.Add(index < list.Count ? list[index] : null);
    }
    foreach ( var list in result )
    {
      string str = "";
      foreach ( var item in list )
        str += ( item == null ? "(null)" : item ) + " ";
      str.TrimEnd(' ');
      Console.WriteLine(str);
    }
