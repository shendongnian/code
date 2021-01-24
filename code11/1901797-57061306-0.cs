    List<Tuple<string, string>> ranges = new List<Tuple<string, string>>();
    string str1 = null;
    string str2 = null;
    for (int i = 0; i < dt_range.Count; i++)
    {
        if (valid[i])
        {
            if (str1 == null)
            {
                str1 = dt_range[i];
            }
            str2 = dt_range[i];
        }
        else
        {
            if (str1 != null)
            {
                ranges.Add(Tuple.Create(str1, str2));
            }
            str1 = null;
        }
    }
    if (str1 != null)
    {
        ranges.Add(Tuple.Create(str1, str2));
    }
