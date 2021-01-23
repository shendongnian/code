    while (!listOfQueueItems.IsEmpty)
    {
        if (listOfQueueItems.TryDequeue(out o))
        {
            // use the data
        }
    }
