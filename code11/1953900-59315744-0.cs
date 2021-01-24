    public List<int> StartFrom(int[] list, int start)
    {
        if (start < 0 || start > list.Length)
            return null;
        var ret = new List<int>();
        for (var i = start; i < list.Length; i++)
            ret.Add(list[i]);
        for (var i = 0; i < start; i++)
            ret.Add(list[i]);
        return ret;
    }
    var result = StartFrom(intList1.ToArray(), 2); // { 2,8,5,7,1,4}
    result = StartFrom(intList1.ToArray(), 5); // {7,1,4,2,8,5} 
