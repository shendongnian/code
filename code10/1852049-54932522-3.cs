    public static class Matcher
    {
        public static (TypeOfMatch, string) Match(
            string nodeName, string nodeValue, string sourceParty,
            string destinationParty, List<Translation> translations)
        {
            return
                translations.Where(xyz).Select(t => (TypeOfMatch.Exact, t)).FirstOrNull() ??
                translations.Where(abc).Select(t => (TypeOfMatch.Default, t)).FirstOrNull() ??
                translations.Where(sss).Select(t => (TypeOfMatch.AnySource, t)).FirstOrNull() ??
                (TypeOfMatch.Other, nodeValue);
        }
    }
    public static class EnumerableExtensions
    {
        public static T? FirstOrNull<T>(this IEnumerable<T> source)
            where T : struct
        {
            return (T?)source.FirstOrDefault() ?? null;
        }
    }
