    public class Socket
    {
        public class Item { }
        private class PendingSend
        {
            public ManualResetEventSlim ManualResetEvent { get; set; }
            public bool Success { get; set; }
            public string Message { get; set; }
            public Exception InnerException { get; set; }
        }
        private readonly object sendLock = new object();
        private readonly object receiveLock = new object();
        private readonly ManualResetEventSlim receiveAvailable
            = new ManualResetEventSlim(false);
        private readonly SemaphoreSlim receiveSemaphore 
            = new SemaphoreSlim(1, 1);
        private readonly ConcurrentQueue<Item> sendQueue
            = new ConcurrentQueue<Item>();
        private readonly ConcurrentQueue<PendingSend> pendingSendQueue
            = new ConcurrentQueue<PendingSend>();
        private readonly ConcurrentQueue<Item> receiveQueue
            = new ConcurrentQueue<Item>();
        // Called from any client thread.
        public void Send(Item item, CancellationToken token)
        {
            // initialize handle to wait for.
            using (var handle = new ManualResetEventSlim(false))
            {
                var pendingSend = new PendingSend
                {
                    ManualResetEvent = handle
                };
                // Make sure the item and pendingSend are put in the same order.
                lock (this.sendLock)
                {
                    this.sendQueue.Enqueue(item);
                    this.pendingSendQueue.Enqueue(pendingSend);
                }
                // Wait for the just created send handle to notify.
                // May throw operation cancelled, in which case the message is
                // still enqueued... Maybe fix that later.
                handle.Wait(token);
                if (!pendingSend.Success)
                {
                    // Now we actually have information why the send 
                    // failed. Pretty cool.
                    throw new CommunicationException(
                        pendingSend.Message, 
                        pendingSend.InnerException);
                }
            }
        }
        // Called by internal worker thread.
        internal Item DequeueForSend()
        {
            this.sendQueue.TryDequeue(out Item result);
            // May return null, that's fine
            return result;
        }
        // Called by internal worker thread, in the same order items are dequeued.
        internal void SendNotification(
            bool success,
            string message,
            Exception inner)
        {
            if (!this.pendingSendQueue.TryDequeue(out PendingSend result))
            {
                throw new InvalidOperationException(
                    "No pending sends remaining.");
            }
            result.Success = success;
            result.Message = message;
            result.InnerException = inner;
            // Releases that waithandle in the Send() method.
            // The 'PendingSend' instance now contains information about the send.
            result.ManualResetEvent.Set();
        }
        // Called by any client thread.
        public Item Receive(CancellationToken token)
        {
            // This makes sure clients fall through one by one.
            this.receiveSemaphore.Wait(token);
            try
            {
                // This makes sure a message is available.
                this.receiveAvailable.Wait(token);
                if (!this.receiveQueue.TryDequeue(out Item result))
                {
                    // TODO: Log a horrible bug has occurred.
                }
                // Make sure the count check and the reset happen in a single go.
                lock (this.receiveLock)
                {
                    if (this.receiveQueue.Count == 0)
                    {
                        this.receiveAvailable.Reset();
                    }
                }
                return result;
            }
            finally
            {
                // make space for the next receive
                this.receiveSemaphore.Release();
            }
        }
        // Called by internal worker thread.
        internal void EnqueueReceived(Item item)
        {
            this.receiveQueue.Enqueue(item);
            // Make sure the set and reset don't intertwine
            lock (this.receiveLock)
            {
                this.receiveAvailable.Set();
            }
        }
    }
