c#
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> target)
        {
            foreach (var item in target)
            {
                yield return item;
            }
        }
        Console.WriteLine("ForEach:");
        foreach (var item in array.ForEach())
            Console.WriteLine(item);
