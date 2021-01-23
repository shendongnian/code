    public class WeightedValueStore<T> : IDisposable
    {
      private static readonly Random Generator = new Random();
      private readonly List<Tuple<int, T>> _values = new List<Tuple<int, T>>();
      private readonly ReaderWriterLockSlim _valueLock = new ReaderWriterLockSlim();
      public void AddValue(int weight, T value)
      {
        _valueLock.EnterWriteLock();
        try 
        {
          _values.Add(Tuple.Create(weight, value));
        }
        finally
        {
          _valueLock.ExitWriteLock();
        }
      }      
      public T GetValue() 
      {
        _valueLock.EnterReadLock();
        try
        {
          var totalWeight = _values.Sum(t => t.Item1);
          var next = Random.Next(totalWeight);
          foreach (var tuple in _values)
          {
            next -= tuple.Item1;
            if (next < 0) return tuple.Item2;
          }
          return default(T); // Or throw exception here - only reachable if _values has no elements.
        }
        finally
        {
          _valueLock.ExitReadLock();
        }
      }
      public void Dispose()
      {
        _valueLock.Dispose();
      }
    }
