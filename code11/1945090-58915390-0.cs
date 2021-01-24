        public static async Task<ICollection<T>> AllResultsAsync<T>(this IAsyncEnumerable<T> asyncEnumerable)
        {
            var list = new List<T>();
            await foreach (var t in asyncEnumerable)
            {
                list.Add(t);
            }
            return list;
        }
