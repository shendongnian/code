    public static string GetReorderedEnumCode<T>()
    {
        var t = typeof (T);
        if (!t.IsEnum)
        {
            throw new ApplicationException("metod requires enum as type parameter");
        }
        var sb = new StringBuilder();
        sb.Append(string.Format(@"public enum {0}
    {{
    ", t.Name));
        var names = Enum.GetNames(t);
        var vals = (int[])Enum.GetValues(t);
        Enumerable.Range(0, vals.Length)
                    .Select(i => Tuple.Create(names[i], vals[i]))
                    .OrderBy(t2 => t2.Item1)
                    .ToList()
                    .ForEach(r => sb.Append(string.Format("     {0} = {1},",
        r.Item1, r.Item2) + Environment.NewLine));
        return sb.ToString().TrimEnd(',') + "}";
    }
    public enum TestEnum
    {
        FirstValue,
        AnotherValue,
        LastValue
    }
    var tmp = Utility.GetReorderedEnumCode<TestEnum>();
    Debug.Write(tmp);
