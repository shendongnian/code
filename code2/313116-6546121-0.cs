    private void DequeueItem()
    {
        object o = null;
        while(socket.Connected)
        {
            if (listOfQueueItems.IsEmpty)
            {
                Thread.Sleep(50);
            }
            else if (listOfQueueItems.TryDequeue(out o))
            {
                // use the data
            }
        }
    }
