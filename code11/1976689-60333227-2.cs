    private readonly ConcurrentStack<string> receivedStrings = new ConcurrentStack<string>();
    private void Update()
    {
        if(receivedStrings.TryPop(out var message))
        {
            text2 = message;
            print(">> " + message);
            // dump all previous messages
            receivedStrings.Clear();
        }
    }
