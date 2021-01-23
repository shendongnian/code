    public int GetIndexesForPositives(out int[] indizes)
    {
        indizes = new int[Length];
        var idI = 0;
    
        for (var i = 0; i < Length; i++)
            {
                if (Get(i))
                {
                    indizes[idI++] = i;
                }
            }
        return idI;
    }
