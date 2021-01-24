    internal static class SqlKataExt
    {
        internal static Join On(this Join j, List<Tuple<string, string>> onConditions, string op = "=")
        {
            foreach (var o in onConditions)
            {
                j = j.On(o.Item1, o.Item2);
            }
            return j;
        }
    }
