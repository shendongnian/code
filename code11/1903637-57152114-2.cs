    private static int[][] GetArrays(int[] intputArray)
    {
        // use lists for dynamically adding elements
        var outputLists = new List<List<int>>();
        // initialize with the ignored value
        var lastValue = -1;
        // iterate over the inputArray
        foreach (var value in intputArray)
        {
            // skip -1 values
            if (value < 0)
            {
                lastValue = -1;
                continue;
            }
            // if a new value begin a new list
            if (lastValue != value)
            {
                outputLists.Add(new List<int>());
            }
            // add the value to the current (= last) list
            outputLists[outputLists.Count - 1].Add(value);
            // update the lastValue
            lastValue = value;
        }
        // convert to arrays
        // you could as well directly return the List<List<int>> instead
        // and access the values exactly the same way
        // but since you speak of buffers I guess you wanted arrays explicitely
        var outputArrays = new int[outputLists.Count][];
        for (var i = 0; i < outputLists.Count; i++)
        {
            outputArrays[i] = outputLists[i].ToArray();
        }
        return outputArrays;
    }
    
