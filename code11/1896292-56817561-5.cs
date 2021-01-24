    public static class ExtensionMethods
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null) throw new NullReferenceException($"'{nameof(enumerable)}' argument is null");
            using var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext()) action(enumerator.Current);
        }
    }
