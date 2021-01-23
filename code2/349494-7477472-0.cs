    HashSet<string> set = new HashSet<string>();
    
    bool inserted = set.Add("Item");
    bool insertedDuplicate = set.Add("Item");
    
    inserted.Dump("Result1");
    insertedDuplicate.Dump("Result2");
    
    //Result
    //Result1 = true
    //Result2 = false
