        public static void AddRange<T>(this ICollection<T> source, IEnumerable<T> elements)
        {
            foreach (T element in elements)
            {
                source.Add(element);
            }
        }
