    int i = 0, last;
    while (i < seriesData.Count)
    {
        if (seriesData[i].Contains(null))
        {
            last = seriesData.Count - 1;
            seriesData[i] = seriesData[last];
            seriesData.RemoveAt(last);
        } else {
            i++;
        }
    }
