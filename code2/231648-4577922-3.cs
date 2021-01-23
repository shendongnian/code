        static IEnumerable<T> MergeShuffle<T>(IEnumerable<T> lista, IEnumerable<T> listb)
        {
            int total = lista.Count() + listb.Count();
            var random = new Random();
            var indexes = Enumerable.Range(0, total-1)
                                    .OrderBy(_=>random.NextDouble())
                                    .Take(lista.Count())
                                    .OrderBy(x=>x)
                                    .ToList();
            var first = lista.GetEnumerator();
            var second = listb.GetEnumerator();
            for (int i = 0; i < total; i++)
                if (indexes.Contains(i))
                {
                    first.MoveNext();
                    yield return first.Current;
                }
                else
                {
                    second.MoveNext();
                    yield return second.Current;
                }
        }
