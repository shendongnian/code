    private object _lockMe = new object();
    void RemoveItem(object source, ElapsedEventArgs e)
    {
        lock(_lockMe)
        {
            int listCount = list.Count;
            if (listCount > 0)                   // This condition is successfully passed, so there is at least one element on the list
            {
                list.RemoveAt(0);            // This line throw an IndexOutOfRangeException error
            }
         }
    }
