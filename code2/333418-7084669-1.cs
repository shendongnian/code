    Array arr = (Array)(object)Document.
                GetCrossReferenceItems(WdReferenceType.wdRefTypeHeading);
    // works
    String arr_elem = arr.GetValue(1);
    // now works
    IEnumerable list = (IEnumerable)arr; 
    // now works
    foreach (String str in arr)
    {
        Console.WriteLine(str);
    }
