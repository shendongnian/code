    public class Synchoniser {
    
      private int _progress;
      private int _total;
      private int _counter;
      pricate object _sync;
    
      public Synchroniser(int total, int counterSeed) {
        _progress = 0;
        _total = total;
        _counter = counterSeed;
        _sync = new Object();
      }
    
      public void AdvanceProgress() {
        lock (_sync) {
          _progress++;
        }
      }
    
      public int GetProgress() {
        lock (_sync) {
          return 100 * _progress / _total;
        }
      }
    
      public int GetNextCounter() {
        lock (_sync) {
          _counter++;
          return _counter;
        }
      }
    
    }
