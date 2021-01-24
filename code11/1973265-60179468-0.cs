    private string ConcatInts()
    {
        List<int> intList = new List<int> {1, 2, 3, 4, 1};
        var buffer = new StringBuilder();
        var len = intList.Count;
        for (var i = 0; i < len; ++i)
        {
            if (i > 0 && i < len - 1)
            {
                buffer.Append(", ");
            }
            else if (i == len - 1)
            {
                buffer.Append(", and ");
            }
            buffer.Append(intList[i].ToString());
        }
        return buffer.ToString();
    }
