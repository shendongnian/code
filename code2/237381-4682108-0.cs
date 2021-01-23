    int[] array = { 1, 2, 3, 4, 7, 8, 11, 15, 16, 17, 18};
    List<string> ranges = new List<string>();
    // code assumes array is not zero-length, is distinct, and is sorted.
    // to do: handle scenario as appropriate if assumptions not valid
    Action<int, int, List<string>> addToRanges = (first, last, list) =>
    {
        if (last == first)
            list.Add(last.ToString());
        else
            list.Add(string.Format("{0}-{1}", first, last)); ;
    };
    int firstItem = array[0];
    int lastItem = firstItem;
    foreach (int item in array.Skip(1))
    {
        if (item > lastItem + 1)
        {
            addToRanges(firstItem, lastItem, ranges);
            firstItem = lastItem = item;
        }
        else
        {
            lastItem = item;
        }
    }
    addToRanges(firstItem, lastItem, ranges);
    // return ranges or ranges.ToArray()
