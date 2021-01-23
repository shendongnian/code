    [Test]
    public void Can_Create_View_Model() {
      var bgWorkerWaitHandle = new AutoResetEvent(false); //Make sure it starts off non-signaled
      var viewModel = new MyViewModel(bgWorkerWaitHandle);
      var didReceiveSignal = bgWorkerWaitHandle.WaitOne(TimeSpan.FromSeconds(5));
      Assert.IsTrue(didReceiveSignal, "The test timed out waiting for the background worker to complete.");
      //Any other test assertions
    }
