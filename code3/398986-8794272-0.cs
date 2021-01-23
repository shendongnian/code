    var stringList = new List<string>();
    
    for (int key = 1; key <= 3; key++)
    {
      ....
      foreach (var item in tabItem)
      {
        stringList.Add("images1/" + "filename2_" + key);
      }
    }
    
    foreach(string in stringList)
    {
      ....
    }
