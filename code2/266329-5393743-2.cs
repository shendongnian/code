    void CheckRelease(object state)
    {
        BufferItem item;
        while (ItemQueue.TryPeek(out item) && item.ReleaseTime >= AppTime)
        {
            if (ItemQueue.TryDequeue(out item))
            {
                // send the item
            }
        }
    }
