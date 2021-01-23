    public static IEnumerable<TItem> GetParallel<TItem, TKey>(Func<TItem, TKey> getKey, params IEnumerable<TItem>[] sources) {
      HashSet<TKey> found = new HashSet<TKey>();
      List<TItem> queue = new List<TItem>();
      object sync = new object();
      int alive = 0;
      object aliveSync = new object();
      foreach (IEnumerable<TItem> source in sources) {
        lock (aliveSync) {
          alive++;
        }
        new Thread(s => {
          foreach (TItem item in s as IEnumerable<TItem>) {
            TKey key = getKey(item);
            lock (sync) {
              if (found.Add(key)) {
                queue.Add(item);
              }
            }
          }
          lock (aliveSync) {
            alive--;
          }
        }).Start(source);
      }
      while (true) {
        lock (sync) {
          if (queue.Count > 0) {
            foreach (TItem item in queue) {
              yield return item;
            }
            queue.Clear();
          }
        }
        lock (aliveSync) {
          if (alive == 0) break;
        }
        Thread.Sleep(100);
      }
    }
