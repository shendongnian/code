    public int[] GetIndexesForPositives()
    {
        var idIndexes = new LinkedList<int>();
    
        for (var i = 0; i < Length; i++)
            {
                if (Get(i))
                {
                    idIndexes.Add(i);
                }
            }
        return idIndexes.ToArray();
    }
