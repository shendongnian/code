    public static int[] GetIndexesForPositives()
    {
        var idIndexes = new List<int>();
        for (var i = 0; i < _data.Length; i++)
        {
            byte _b = _data[i];
            if (_b > 0)
            {
                for (var j = 0; j < 8; j++)
                {
                    if ((_b & (1 << j)) > 0)
                    {
                        idIndexes.Add(i * 8 + j);
                    }
                }
            }
        }
        return idIndexes.ToArray();
    }
