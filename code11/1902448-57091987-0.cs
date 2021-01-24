    class Program
    {
        static void Main()
        {
            string myFirstArg = "arg0";
            var format = "(0:'{0}';1:'{1}';2:'{2}')";
            var args = new object[] { "arg1", "arg2" };
            var result = string.Format(format, args.Prepend(myFirstArg).ToArray());
        }
    }
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> collection, T element)
        {
            yield return element;
            foreach (var e in collection) yield return e;
        }
    }
