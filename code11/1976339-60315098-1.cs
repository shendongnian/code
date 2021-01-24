    interface IWriteStrategy
    {
        void Write(IMaster thing);
    }
    class WriterA : IWriteStrategy
    {
        public void Write(IMaster thing)
        {
            Console.WriteLine("Writer A");
            thing.ExecuteMaster();
        }
    }
    class WriterB : IWriteStrategy
    {
        public void Write(IMaster thing)
        {
            Console.WriteLine("Writer B");
            thing.ExecuteMaster();
        }
    }
