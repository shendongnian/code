    private List<List<int>> arrays = new List<List<int>>();
    private int lastValue;
    private void AddValue(int value)
    {
        // skip -1 values
        if (value < 0)
        {
            lastValue = -1;
            return;
        }
    
        // if a new value begin a new list
        if (lastValue != value)
        {
            arrays.Add(new List<int>());
        }
    
        // add the value to the current (= last) list
        arrays[outputLists.Count - 1].Add(value);
    
        // update the lastValue
        lastValue = value;
    }
