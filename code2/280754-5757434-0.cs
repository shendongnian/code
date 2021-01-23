    public static IEnumerable<IEnumerable<T>> Permute<T>(IEnumerable<T> list)
            {
                if (list.Count() == 1)
                    return new List<IEnumerable<T>> { list };
    
                return list.Select((a, i1) => Permute(list.Where((b, i2) => i2 != i1)).Select(b => (new List<T> { a }).Union(b)))
                           .SelectMany(c => c);
            }
    List<int> list1 = Enumerable.Range(1, 3).ToList();
    
    Permute(list1);
