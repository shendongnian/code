    int i = 0;
    while (i < seriesData.Count)
    {
        if (seriesData[i].Contains(null))
        {
            seriesData.RemoveAt(i);
        } else {
            i++;
        }
    }
