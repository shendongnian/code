    {
        IEnumerator<IEnumerable> e = ((IEnumerable<IEnumerable>)(x)).GetEnumerator(); 
        try
        {
            StringComparer v; 
            while (e.MoveNext())
            {
                v = (StringComparer)(IEnumerable)e.Current; // (*)
                // do something here
            }    
        } 
        finally
        {
            // Dispose of e
        }
    }
