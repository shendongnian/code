    // List.BinarySearch returns:
    // The zero-based index of item in the sorted System.Collections.Generic.List`1,
    // if item is found; otherwise, a negative number that is the bitwise complement
    // of the index of the next element that is larger than item or, if there is no
    // larger element, the bitwise complement of System.Collections.Generic.List`1.Count.
    int pos = lists.BinarySearch("d");
    int resultPos = pos >= 0 ? pos : ~pos - 1;
    Console.WriteLine("Result: " + resultPos);
