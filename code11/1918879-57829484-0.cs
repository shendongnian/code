    private static object ToObj(SPCRawDataDTO src)
    {
        var dest = new ExpandoObject() as IDictionary<string, object>;
        dest.Add("ShiftDate", src.ShiftDate);
        dest.Add("ShiftName", src.ShiftName);
        // TODO: add all other properties
        for (var i = 0; i < src.SpecValues.Count; ++i)
        {
            dest.Add($"W{i + 1}", src.SpecValues[i].SpecValue);
        }
        return dest;
    }
