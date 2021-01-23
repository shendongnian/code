    [Test]
    public void GetUserAsyncTest()
    {
        //Action<User> user = null;
        User result;
        ManualResetEvent waitEvent = new ManualResetEvent(false);
        _restTest.GetUserAsync((user) =>
        {
            result = user;
            waitEvent.Set();
        });
        waitEvent.WaitOne();
        Assert.AreEqual("xy", result.Email);
    }
