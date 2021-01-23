    private void onReceiveMessage( Object sender, ReceiveCompletedEventArgs args )
    {
        Message ReceivedMessage = queue.EndReceive( args.AsyncResult );
        //Do whatever you want. Raise a new event, process the message, ...
    }
