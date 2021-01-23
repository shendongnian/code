    // Similar to Patko's idea, except using a 'named' type.
    int[] indices = weekDays.AsSmartEnumerable()
                            .Where(item => item.Value.Contains("s"))
                            .Select(item => item.Index)
                            .ToArray();
