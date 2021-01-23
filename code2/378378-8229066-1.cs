    public static bool IsElementOf(this int n, IEnumerable<int> list)
    {
        return list.Any(i => n == i);
    }
    //usage
    if(3.IsElementOf(list)) //in the list
