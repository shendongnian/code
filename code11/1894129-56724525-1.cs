    File.ReadLines(targetfile).ForEach(line =>
    {
        File.AppendAllText("path", string.Join(":", Regex.Split(line, "@|:")
                                   .Cast<Match>().Select(m => m.Value)));
    });
    static class ExtensionMethods
    {
        internal static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null) throw new NullReferenceException($"'{nameof(enumerable)}' argument is null");
            using var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext()) action(enumerator.Current);
        }
    }
