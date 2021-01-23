    public IEnumerable<int> InfiniteCounter()
    {
        int counter = 0;
        while (true)
        {
            unchecked
            {
                yield return counter;
                counter++;
            }
        }
    }
