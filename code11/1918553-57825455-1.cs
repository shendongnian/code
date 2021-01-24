    foreach (var entry in list.GetRange(25, 477))
    {
        if (entry.Value > maxValue)
        {
            maxValue = entry.Value;
            maxIndex = entry.Index;
        }
    }
