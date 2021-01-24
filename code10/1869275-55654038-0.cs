    // List.BinarySearch returns:
    // The zero-based index of item in the sorted System.Collections.Generic.List`1,
    // if item is found; otherwise, a negative number that is the bitwise complement
    // of the index of the next element that is larger than item or, if there is no
    // larger element, the bitwise complement of System.Collections.Generic.List`1.Count.
    lists.Sort();
    int pos = lists.BinarySearch("d");
    string result = pos >= 0 ? lists[pos] : pos < -1 ? lists[~pos - 1] : null;
    Console.WriteLine("Result: " + (result ?? "Smaller than the smallest"));
