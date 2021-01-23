    List<MyObject> Mylist;
    MyList = GetObjects(TheDate);
    Dictionary<DateTime> myDictionary = new Dictionary<DateTime>();
    myDictionary[TheDate] = MyList;
    Session["DateCollections"] = myDictionary;
