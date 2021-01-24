    var items = new List<Item>();
    
    var itemA = new Item() 
    {
        Name = "A";
    } 
    
    for(int i=0; i<3; i++)
    {
        items.Add(itemA);
    }
    // item list now has 3 A
    var itemB = new Item() 
    {
        Name = "B";
    } 
    
    for(int i = 0; i<2; i++)
    {
        items.Add(itemB);
    }
    // itme list now has 3 A and 2 B
