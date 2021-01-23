    [TestFixture] public class SandboxTesting {
      #region Setup/Teardown
      [SetUp] public void SetUp() {
        _collection = new Collection<int>();
        for(int i = 0; i < 100000000; i++)
          _collection.Add(i);
      }
      [TearDown] public void TearDown() {}
      #endregion
      private Collection<int> _collection;
      private void AnyFirst() {
        if(_collection.Any()) {
          int firstItem = _collection.First();
          Console.WriteLine(firstItem);
        }
      }
      private void NullCheck() {
        int firstItem = _collection.FirstOrDefault();
        if(firstItem!=null)
          Console.WriteLine(firstItem);
      }
      private void ForLoop() {
        foreach(int firstItem in _collection) {
          Console.WriteLine(firstItem);
          break;
        }
      }
      [Test] public void TimeAnyFirstWithLotsOfData() {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        AnyFirst();
        stopwatch.Stop();
        Console.WriteLine("Took {0} seconds", stopwatch.Elapsed);
      }
      [Test] public void TimeForLoopWithLotsOfData() {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        NullCheck();
        stopwatch.Stop();
        Console.WriteLine("Took {0} seconds", stopwatch.Elapsed);
      }
      [Test] public void TimeNullCheckWithLotsOfData() {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        ForLoop();
        stopwatch.Stop();
        Console.WriteLine("Took {0} seconds", stopwatch.Elapsed);
      }
    }
