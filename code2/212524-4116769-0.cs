    [Test, Isolated]
    public void HeardTalk_GetsCalled()
    {
        // --- Arrange ---
        var talker = new Talker();
        var listener = new Listener();
        bool heardTalkWasCalled = false;
        Isolate.WhenCalled(() => listener.HeardTalk(null, null))                     // Selectively 'mock' the call to 'listener.HeardTalk()'
                                         .DoInstead(x => heardTalkWasCalled = true); // on the live object (arguments are ignored by default)
        // --- Act ---
        listener.StartListening(talker);
        talker.Talk();
        // --- Assert ---
        Assert.IsTrue(heardTalkWasCalled);
    }
