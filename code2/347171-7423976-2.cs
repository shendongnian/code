    ArrayList poplist;
    void MyMethod()
    {
        List<int> OrderedByPopularity = new List<int>();
        popList = myDicList["popularity"];
        for (int i = 0; i < popList.Count; ++i)
        {
            OrderedByPopularity.Add(i);
        }
        OrderedByPopularity.Sort(PopularityComparison);
        // ...
    }
    int PopularityComparison(int i1, int i2)
    {
        return popList[i2].CompareTo(popList[i1]);
    }
