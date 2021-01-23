    [TestFixture] public class SandboxTesting {
      #region Setup/Teardown
      [SetUp] public void SetUp() {
        _iterations = 10000000;
      }
      [TearDown] public void TearDown() {}
      #endregion
      private int _iterations;
      private void SetCollectionSize(int size) {
        _collection = new Collection<int?>();
        for(int i = 0; i < size; i++)
          _collection.Add(i);
      }
      private Collection<int?> _collection;
      private void AnyFirst() {
        if(_collection.Any()) {
          int? firstItem = _collection.First();
          var x = firstItem;
        }
      }
      private void NullCheck() {
        int? firstItem = _collection.FirstOrDefault();
        if (firstItem != null) {
          var x = firstItem;
        }
      }
      private void ForLoop() {
        foreach(int firstItem in _collection) {
          var x = firstItem;
          break;
        }
      }
      private void TryGetFirst() {
        int? firstItem;
        if (_collection.TryGetFirst(out firstItem)) {
          var x = firstItem;
        }
      }    
      private TimeSpan AverageTimeMethodExecutes(Action func) {
        // clean up
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        // warm up 
        func();
        var watch = Stopwatch.StartNew();
        for (int i = 0; i < _iterations; i++) {
          func();
        }
        watch.Stop();
        return new TimeSpan(watch.ElapsedTicks/_iterations);
      }
      [Test] public void TimeAnyFirstWithEmptySet() {      
        SetCollectionSize(0);
        TimeSpan averageTime = AverageTimeMethodExecutes(AnyFirst);
        Console.WriteLine("Took an avg of {0} secs on empty set", avgTime);     
      }
      [Test] public void TimeAnyFirstWithLotsOfData() {
        SetCollectionSize(1000000);
        TimeSpan avgTime = AverageTimeMethodExecutes(AnyFirst);
        Console.WriteLine("Took an avg of {0} secs on non-empty set", avgTime);      
      }
      [Test] public void TimeForLoopWithEmptySet() {
        SetCollectionSize(0);
        TimeSpan avgTime = AverageTimeMethodExecutes(ForLoop);
        Console.WriteLine("Took an avg of {0} secs on empty set", avgTime);
      }
      [Test] public void TimeForLoopWithLotsOfData() {
        SetCollectionSize(1000000);
        TimeSpan avgTime = AverageTimeMethodExecutes(ForLoop);
        Console.WriteLine("Took an avg of {0} secs on non-empty set", avgTime);
      }
      [Test] public void TimeNullCheckWithEmptySet() {
        SetCollectionSize(0);
        TimeSpan avgTime = AverageTimeMethodExecutes(NullCheck);
        Console.WriteLine("Took an avg of {0} secs on empty set", avgTime);
      }
      [Test] public void TimeNullCheckWithLotsOfData() {
        SetCollectionSize(1000000);
        TimeSpan avgTime = AverageTimeMethodExecutes(NullCheck);
        Console.WriteLine("Took an avg of {0} secs on non-empty set", avgTime);
      }
      [Test] public void TimeTryGetFirstWithEmptySet() {
        SetCollectionSize(0);
        TimeSpan avgTime = AverageTimeMethodExecutes(TryGetFirst);
        Console.WriteLine("Took an avg of {0} secs on empty set", avgTime);
      }
      [Test] public void TimeTryGetFirstWithLotsOfData() {
        SetCollectionSize(1000000);
        TimeSpan averageTime = AverageTimeMethodExecutes(TryGetFirst);
        Console.WriteLine("Took an avg of {0} secs on non-empty set", avgTime);
      }
    }
    public static class Extensions {
      public static bool TryGetFirst<T>(this IEnumerable<T> seq, out T value) {
        foreach(T elem in seq) {
          value = elem;
          return true;
        }
        value = default(T);
        return false;
      }
    }
   
