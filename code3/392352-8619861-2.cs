        public MessageProcessor(int numberOfConsumers = 1)
        {
            for (int i=0;i<numberOfConsumers;++i)
                StartConsumer();
        }
        private void StartConsumer()
        {
           // Move this to constructor to prevent race condition in existing code (you could start multiple threads...
           Task.Factory.StartNew(this.spool, TaskCreationOptions.LongRunning);
        }
