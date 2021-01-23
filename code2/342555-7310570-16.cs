    using(var enumerator = enumerable.GetEnumerator()) 
    {
        while (enumerator.MoveNext())
        {
            object item = enumerator.Current;
            // Perform logic on the item
        }
    }
