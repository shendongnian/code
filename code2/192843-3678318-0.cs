    class NotificationStorageDectorator : StorageDecorator
    {
        public NotificationStorageDectorator(IStorage storage) : base(storage)
        {
        }
        public NotificationStorageDectorator() : this(new FileStorage()){}
        protected override IBin Decorate(BinConfiguration config, IBin bin)
        {
            return new MyNotificationBin(bin);    
        }
        class MyNotificationBin : BinDecorator
        {
            public MyNotificationBin(IBin bin) : base(bin)
            {
            }
            public override void Close()
            {
                base.Close();
                // Implement here your notification-mechanism
                // For example with events etc
                Console.Out.WriteLine("Backup-done");
            }
        }
    }
