    int[] ints1 = { 5, 3, 9, 7, 5, 9, 3, 7 };
    int[] ints2 = { 8, 3, 6, 4, 4, 9, 1, 0 };
    IEnumerable<int> union = ints1.Union(ints2);
    foreach (int num in union)
    {
         Console.Write("{0} ", num);
    }
    /*
    This code produces the following output:
    5 3 9 7 8 6 4 1 0
    */
