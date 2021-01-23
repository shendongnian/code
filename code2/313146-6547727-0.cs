    var dataPath = column.SortMemberPath.Split(new char[] { '.' });
    [...]
    foreach (var item in (System.Collections.IList)myObject)
    {
       var newItem = item;
    
       foreach (var path in dataPath)
       {
             var actalValue = newItem.GetType().GetProperty(path).GetValue(newItem, null);
             newItem = actalValue; //it does the trick
       }
       now, the newItem is my wanted property value 
    }
