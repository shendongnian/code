csharp
  var tester = testClassManager.LeaseTester();
  // Imagine that testClassManager.Clear(); gets called from the second thread at this point.
  //
  // Since _testerCollectionLock from testClassManager.LeaseTester() is already released, the Clear method from other thread can run as it can acquire the lock now.
  // This thread keeps running, and races to start executing the next line which would set the status to true and prevent the other thread from throwing exception.
  // But it is a nature of race conditions that there is a single winner... and in this case it is the other thread; checking for status which is not yet changed to true and thus throwing the exception :-(
  tester.SetStatusToTrue();
  testClassManager.ReLeaseTester(tester.Id);
The easiest fix in this case would be to set status of the TestClas inside LeaseTester method in the lock block.
csharp
public TestClass LeaseTester()
{
  lock (_testerCollectionLock)
  {
    var tester = new TestClass();
    tester.SetStatusToTrue();
    _leasedTesters.Add(tester.Id, tester);
    _releasedTesters.Remove(tester.Id);
    return tester;
  }
}
