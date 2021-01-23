      List<int> MyList =  new List<int> { 1, 2 };   
      List<List<int>> list = new List<List<int>>();
      list.Add(new List<int> { 0, 1, 2 });
      list.Add(MyList);
      list.Add(new List<int> { 4 });
      list.Add(new List<int> { 0, 1, });
    
      list.Remove(MyList);
