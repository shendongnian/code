    public IEnumerable<KeyValuePair<string,int>> LoadPieChartData
    {
        get
        {
            for (int i = 0; i < 20; i++)
            {
                yield return new KeyValuePair<string, int>("Item " + i, i);
            }
        }
    }
