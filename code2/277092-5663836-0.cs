    try
    {
        var en = test.GetEnumerator(); //creates a ListEnumerator
        T item;
    
        while(en.MoveNext()) // MoveNext increments the current index and returns
                             // true if the new index is valid, or false if it's
                             // beyond the end of the list. If it returns true,
                             // it retrieves the value at that index and holds it 
                             // in an instance variable
        {
            item = en.Current; // Current retrieves the value of the current instance
                               // variable
        }
    }
    finally { }
