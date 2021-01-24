    List<MyItem> listWithDuplicates = ...
    
    var groups = listWithDuplicates
      .GroupBy(item => item);
    
    List<List<MyItem>> allLists = new List<List<MyItem>>();
    
    foreach (var group in groups) {
      int index = 0;
    
      foreach (var item in group) {
        List<MyItem> list;
    
        if (allLists.Count > index)
          list = allLists[index];
        else {
          list = new List<MyItem>();
          allLists.Add(list);  
        }
    
        list.Add(item); 
         
        index += 1;
      }
    }
   
