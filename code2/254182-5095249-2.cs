    [Test]
    public void ExecuteSynchronouslyTest ()
    {
            var val = 0;
            Task t = new Task (() => { Thread.Sleep (100); val = 1; });
            t.RunSynchronously ();
            Assert.AreEqual (1, val);
    }
