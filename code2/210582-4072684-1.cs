    class RandomList<T> : IEnumerable<T> {
         private readonly IList<T> list;
         private readonly Random rg = new Random();
         private readonly object sync = new Object();
         public RandomList(IList<T> list) {
             Contract.Requires<ArgumentNullException>(list != null);
             this.list = list;
         }
         public IEnumerator<T> GetEnumerator() {
             List<int> indexes;
             // Random.Next is not guaranteed to be thread-safe
             lock (sync) {
                 indexes = Enumerable
                     .Range(0, list.Count)
                     .OrderBy(x => rg.Next())
                     .ToList();
             }
             foreach (var index in indexes) {
                 yield return list[index];
             }
         }
    }
          IEnumerator IEnumerable.GetEnumerator() {
              return GetEnumerator();
          }
    }
