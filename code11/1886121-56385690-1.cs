    public void Start()
    {
        lock (orderQueue)
        {
            Enabled = true;
            Monitor.Pulse(orderQueue);
        }
    }
    public void Stop()
    {
        lock (orderQueue)
        {
            Enabled = false;
            Monitor.Pulse(orderQueue);
        }
    }
    void QueueOrder(OrderItemTask task)
    {
        lock (orderQueue)
        {
            orderQueue.Enqueue(task);
            Monitor.Pulse(orderQueue);
        }
    }
