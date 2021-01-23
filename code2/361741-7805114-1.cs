    private void OnMessageAdded( IAsyncResult ar )
    {
        Message peekedMessage = queue.EndPeek(ar);
        //Do whatever you want. Raise a new event, process the message, ...
    }
