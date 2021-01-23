    var myObjects = new List<MyObject>(); // fill        
    var groups = from item in myObjects group item by item.SomeNumber;
    // alternatively:
    // var groups = myObjects.GroupBy(item => item.SomeNumber)
    
    foreach (var g in groups)
    {
        var someNumber = g.Key;
        var members = g.ToList();
    }
