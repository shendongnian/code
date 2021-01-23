      // just 4 fun
      public static IEnumerable<T> TakeMin<T, TKey>(this IEnumerable<T> @this, 
            int n, Func<T, TKey> selector)            
             where TKey: IComparable<TKey>
      {
            var tops = new SortedList<TKey, T>(n+1);
            foreach (var item in @this)
            {
                TKey k = selector(item);
                if (tops.ContainsKey(k))
                    continue;
                if (tops.Count < n)
                {
                    tops.Add(k, item);
                }
                else if (k.CompareTo(tops.Keys[tops.Count - 1]) < 0)
                {
                    tops.Add(k, item);
                    tops.RemoveAt(n);
                }                                    
            }
            return tops.Values;
        }
