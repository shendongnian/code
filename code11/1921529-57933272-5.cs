    IEnumerable<string> enumerable = new List<string> { "a", "b", "c" };
    //you write
    foreach (string element in enumerable)
    {
        Console.WriteLine(element);
    }
         
    //the compiler writes
    string element;   
    var enumerator = enumerable.GetEnumerator();
    try
    {
        while (enumerator.MoveNext())
        {
            element = enumerator.Current;
            //begin your foreach body code
            Console.Write(element); 
            //end your foreach body code
        }
    }
    finally
    {
        enumerator.Dispose();
    }
