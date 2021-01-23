    IEnumerable<int> SortToMiddle(IEnumerable<int> input) 
    {
        bool sendToFirst = true;
        SortedList<int> sorted = new SortedList<int>(input);
        SortedList<int> firstHalf = new SortedList<int>(); 
        SortedList<int> secondHalf = new SortedList<int>();
        
        foreach (var current in sorted)
        {
            if (sendToFirst)
            {
                firstHalf.Add(current);
            }
            else
            {
                secondHalf.Add(current);
            }
            sendToFirst = !sendToFirst;
        }
        return new List<int>(firstHalf.Concatenate(secondHalf.Reverse());
    }
