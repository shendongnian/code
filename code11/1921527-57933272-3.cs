    IEnumerable<string> enumerable = new List<string> { "a", "b", "c" };
    //you write
    foreach (string element in enumerable)
    {
        Console.WriteLine(element);
    }
         
    //the compiler writes   
    var enumerator = enumerable.GetEnumerator();
    try
    {
        while (enumerator.MoveNext())
        {
            Console.Write(enumerator.Current); //your reference for it was "element"
        }
    }
    finally
    {
        enumerator.Dispose();
    }
