    var a1 = new ObservableCollection<TestObjectWithTempID>();
    var a2 = new ObservableCollection<IObjectWithTempID>();
    //a1.FindByTempID(1); /* Is not a collection of interface */
    a1.FindByTempID2(1); // IEnumerable<T> is a generic list
    a1.FindByTempID3(1); // It is a collection of TestObjectWithTempID
    a1.FindByTempID4(1); // Identify the collection as ObservableCollection<TestObjectWithTempID>
    a2.FindByTempID(1); // Is a collection of interface
    a2.FindByTempID2(1); // IEnumerable<T> is a generic list
    //a2.FindByTempID3(1); /* Is not a collection of TestObjectWithTempID */
    a2.FindByTempID4(1); // Identify the collection as ObservableCollection<IObjectWithTempID>
