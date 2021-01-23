    {
        IEnumerator<int> e = ((IEnumerable<int>)values).GetEnumerator(); // <-- This
                                                           // is where the Enumerator
                                                           // comes from.
        try
        { 
            int m; // OUTSIDE THE ACTUAL LOOP
            while(e.MoveNext())
            {
                // loop code goes here
            }
        }
        finally
        { 
          if (e != null) ((IDisposable)e).Dispose();
        }
    }
