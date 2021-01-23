    public IEnumerable<aPoint> GetPoints()
    {
        while(WeHaveMoreData)
        {
            yield return new aPoint();
        }
    }
