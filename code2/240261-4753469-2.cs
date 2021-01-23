    private void TransactionConsumer()
    {
        Transaction trans;
        while (queue.TryTake(out trans, Timeout.Infinite))
        {
            // process transaction
        }
        // Collection is empty
    }
