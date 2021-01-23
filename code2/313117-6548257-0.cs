    private void _DequeueItem()
    {
        while(socket.Connected)
        {
            object o = listOfQueueItems.Take();
            // use the data
        }
    }
