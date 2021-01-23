    {
        IEnumerator<int> e = ((IEnumerable<int>)values).GetEnumerator(); // <-- This
                                                           // is where the Enumerator
                                                           // comes from.
        try
        { 
            int m; // OUTSIDE THE ACTUAL LOOP in C# 4 and before, inside the loop in 5
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
