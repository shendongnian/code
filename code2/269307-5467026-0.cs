        // in a static class in a namespace you can see
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> second, IEnumerable<T> first)
        {
            foreach (var x in first)
            {
                yield return x;
            }
            foreach (var x in second)
            {
                yield return x;
            }
        }
        ...
        var newListOfMonths = listOfMonths.Prepend(someExtraItems).ToList();
