        public static string RemoveLast(this string source, string value)
        {
            int index = source.LastIndexOf(value);
            return index != -1 ? source.Remove(index, value.Length) : source;
        }
