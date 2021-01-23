    public IEnumerable<int> GetIndexesForPositives()
    {
        for (var i = 0; i < Length; i++)
            {
                if (Get(i))
                {
                    yield return i;
                }
            }
    }
