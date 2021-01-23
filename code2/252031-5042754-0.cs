    [Test]
    public void DemonstrateThatTheTestRunsAsFastAsTheSubjectUnderTest()
    {
         var resetEvent = new ManualResetEvent(true);
         // configure our test to listen for the completed event
         var subject = new MyTestSubject();
         subject.OnComplete += (sender,e) => resetEvent.Set();
         // perform the long running asynchronous operation
         subject.DoLongRunningOperation();
         // wait up to 10 seconds
         resetEvent.WaitOne(100000);
         Assert.AreTrue(subject.OperationComplete);
    }
