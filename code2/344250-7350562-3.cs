    {
        E e = ((C)(x)).GetEnumerator();
        try 
        {
            V v;
            while (e.MoveNext()) 
            {
                v = (V)(T)e.Current;
                embedded-statement
            }
        }
        finally 
        {
             code to Dispose e if necessary
        }
    }
