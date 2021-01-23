    [TestMethod]
    public void Test()
    {
        MessageLoopTestRunner.Run(
      
            // the logic of the test that should run on top of a message loop
            runner =>
            {
                var myObject = new ComObject();
                            
                myObject.MyEvent += (source, args) =>
                {
                    Assert.AreEqual(5, args.Value);
                    // tell the runner we don't need the message loop anymore
                    runner.Finish();
                };
                myObject.TriggerEvent(5);
            },
            // timeout to terminate message loop if test doesn't finish
            TimeSpan.FromSeconds(3));
    }
