    int[] array = new int[] { 0, 1, 2 };
    object obj=array;
    IEnumerable<object> collection = (IEnumerable<object>)array;
    
    foreach (object item in collection)
    {
        Console.WriteLine(item.ToString());
    }
