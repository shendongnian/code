    for(int i = lineList.Count - 1; i >= 0; i--)
    {
        if (lineList[i].Contains("FID") || lineList[i].Contains("EXCLUDE"))
           lineList.RemoveAt(i);
    }
