    int[] array = ..
    
    // Will throw if the array is empty.
    // If there are duplicate minimum values, the one with the smaller
    // index will be chosen.
    int minIndex = array.AsSmartEnumerable()
                        .MinBy(entry => entry.Value)
                        .Index;
