    static class MergeExtension
    {
        public static ExpandoObject Merge<TLeft, TRight>(this TLeft left, TRight right)
        {
            var expando = new ExpandoObject();
            IDictionary<string, object> dict = expando;
            foreach (var p in typeof(TLeft).GetProperties())
                dict[p.Name] = p.GetValue(left);
            foreach (var p in typeof(TRight).GetProperties())
                dict[p.Name] = p.GetValue(right);
            return expando;
        }
    }
