    List<int> myIntCollection=new List<int>();
    myIntCollection.Add(42);
    List<int> newCollection=new List<int>(myIntCollection.Count);
    
    foreach(int i in myIntCollection)
    {
        if (i want to delete this)
            ///
        else
            newCollection.Add(i);
    }
    myIntCollection = newCollection;
