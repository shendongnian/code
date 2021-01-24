    public static IReadOnlyCollection<T1> All<T1>(this ICollection<T1> storage)
            {
                if(storage.Count > 0)
                {
                    return new List<T1>(storage);
                }
                else
                {
                    return new List<T1>();
                }
            }
