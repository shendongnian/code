    List<MyObject> myList = new List<MyObject>();
    myList.Add(new MyObject { ObjectID = 1, Prop1 = "Something" });
    myList.Add(new MyObject { ObjectID = 2, Prop1 = "Another thing" });
    myList.Add(new MyObject { ObjectID = 3, Prop1 = "Yet another thing" });
    myList.Add(new MyObject { ObjectID = 1, Prop1 = "Something" });
    var duplicatesRemoved = myList.Distinct().ToList();
