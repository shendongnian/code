    while (true)
    {
        var msg = queue1.GetMessage();
        if (msg != null)
        {
            didSomething = true;
            // do something with it
            queue1.DeleteMessage(msg);
        }
        msg = queue2.GetMessage();
        if (msg != null)
        {
            didSomething = true;
            // do something with it
            queue2.DeleteMessage(msg);
        }
        // ...
        if (!didSomething) Thread.Sleep(TimeSpan.FromSeconds(1)); // so I don't enter a tight loop with nothing to do
    }
