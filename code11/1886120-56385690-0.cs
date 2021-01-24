    void ProcessOrderWorker()
    {
        while (true)
        {
            lock (orderQueue) // acquire the lock
            {
                while (!Enabled || orderQueue.Count == 0) // waiting condition
                {
                    Monitor.Wait(orderQueue); // here the lock is released
                                              // while waiting for a pulse
                }
            }
            maxConcurrency.Wait();
            lock (orderQueue)
            {
                if (orderQueue.Count > 0)
                {
                    var batch = new List<OrderItemTask>();
                    while (orderQueue.Count > 0)
                        batch.Add(orderQueue.Dequeue());
                    placeOrderStrategy.PlaceOrder(batch);
                }
            }
            maxConcurrency.Release();
        }
    }
