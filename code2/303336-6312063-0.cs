    int[] arr = //this is the integer array
    IEnumerable Collection = //This is your EF4 collection
    for (int i = 0; i < Collection.Count; ++i)
    {
        arr.Any(a => a == Collection[i].ID) ? /* display yes */ : /* display no */;
    }
