    public static int[] GetIndexesForPositives(int length)
    {
        var idIndexes = new int[length];
        var idx = 0;
        System.Reflection.FieldInfo field = data.GetType().GetField("m_array", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        int[] values = field.GetValue(data) as int[];
        for (var i = 0; i < values.Length; i++)
        {
            int _i = values[i];
            if (_i != 0)
            {
                for (var j = 0; j < 32; j++)
                {
                    if ((_i & (1 << j)) != 0)
                    {
                        idIndexes[idx++] = i * 32 + j;
                    }
                }
            }
    }
