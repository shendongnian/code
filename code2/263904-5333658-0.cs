    foreach(string item in selectedObjects.Split(new [] {';'}, 
                                                 StringSplitOptions.RemoveEmptyEntries)
                                          .Select( x=> x+";"))
    {
       //process item
    }
