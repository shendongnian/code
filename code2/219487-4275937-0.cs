    var myList = (from s in dataContect.Users select s).ToList();
    
    bool containsNull = false;
    
    foreach(var item in mylist)
    {
    if(string.IsNullOrEmpty(item.LastName))
    {
    containsNull = true;
    }
    }
    
    if(!containsNull)
    {
    // If is not contains null, Use Order By
    myList = myList.OrderBy(k => k....);
    }
