        IEnumerable<T> DelayedConcat<T>(params Func<IEnumerable<T>>[] enumerableList)
        {
            foreach(var enumerable in enumerableList)
            {
                foreach (var item in enumerable())
                {
                    yield return item;
                }
            }
        }
