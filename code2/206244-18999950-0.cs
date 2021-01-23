     public static class ObservableCollection
     {
          public static void Sort<TSource, TKey>(this ObservableCollection<TSource> source, Func<TSource, TKey> keySelector)
          {
              List<TSource> sortedList = source.OrderBy(keySelector).ToList();
              source.Clear();
              foreach (var sortedItem in sortedList)
              {
                  source.Add(sortedItem);
              }
         }
     }
