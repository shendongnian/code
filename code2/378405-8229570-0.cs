    var myList = new List<List<CustomClass>>();
    
    //populate myList
    
    var clonedList = new List<List<CustomClass>>();
    
    //here's the beef
    foreach(var sublist in myList)
    {
       var newSubList = new List<CustomClass>();
       clonedList.Add(newSubList);
       foreach(var item in sublist)
          newSublist.Add(item.Clone());
    }
