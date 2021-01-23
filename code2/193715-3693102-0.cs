    class DisposableCollection<T> : IDisposable, IEnumerable<T> 
                                    where T : IDisposable {
      IEnumerable<T> en; // Wrapped enumerable
      List<T> garbage;   // To keep generated objects
    
      public DisposableCollection(IEnumerable<T> en) {
        this.en = en;
        this.garbage = new List<T>();
      }
      // Enumerates over all the elements and stores generated
      // elements in a list of garbage (to be disposed)
      public IEnumerator<T> GetEnumerator() { 
        foreach(var o in en) { 
          garbage.Add(o);
          yield return o;
        }
      }
      // Dispose all elements that were generated so far...
      public Dispose() {
        foreach(var o in garbage) o.Dispose();
      }
    }
