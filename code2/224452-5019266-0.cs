    public static class ExtensionMethods
    {
        public static string[] Wrap(this string text, int max)
        {
            var charCount = 0;
            var lines = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return lines.GroupBy(w => (charCount += w.Length + 1) / (max + 2))
                        .Select(g => string.Join(" ", g.ToArray()))
                        .ToArray();
        }
    }
