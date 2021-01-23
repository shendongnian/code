    Ienumrator<int> rator = MyList.GetEnumrator();
    try
    {
       while(rator.MoveNext())
       {
           int i = rator.Current; 
           Console.WriteLine(i); 
       }
    }
    finally
    {
        rator.Dispose()
    }
 
 
