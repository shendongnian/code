    class MessageProcessor : IDisposable
    {
        BlockingCollection<IMyMessage> messages = new BlockingCollection<IMyMessage>();
        public MessageProcessor()
        {
           // Move this to constructor to prevent race condition in existing code (you could start multiple threads...
           Task.Factory.StartNew(this.spool, TaskCreationOptions.LongRunning);
        }
        public void AddMessage(IMyMessage message)
        {
            this.messages.Add(message);
        }
        private void Spool()
        {
             foreach(IMyMessage message in this.messages.GetConsumingEnumerable())
             {
                   // long running thing that does something with this message.
             }
        }
        public void FinishProcessing()
        {
             // This will tell the spooling you're done adding, so it shuts down
             this.messages.CompleteAdding();
        }
        void IDisposable.Dispose()
        {
            this.FinishProcessing();
        }
    }
