    private object[,] Dictionary2Array(Dictionary<object, object> dic)
    {
        object[,] arr = new object[dic.Count, 2];
        int i = 0;
        foreach (KeyValuePair<object, object> item in dic)
        {
            arr[i, 0] = item.Key;
            arr[i, 1] = item.Value;
            i++;
        }
        return arr;
    }
