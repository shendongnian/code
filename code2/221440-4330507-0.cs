        public static string CommaSeparate(this IEnumerable<string> values)
        {
            if (values.Count() == 0) return "[none]";
            return string.Join(", ", values.ToArray());
        }
