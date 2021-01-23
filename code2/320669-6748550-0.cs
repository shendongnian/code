    class Syncronizer
    {
        public delegate void SynchronizatonEventHandler(MyClass myClass);
        private event SynchronizatonEventHandler onSyncFinished;
        public event SynchronizatonEventHandler OnSyncFinished
        {
            add
            {
                var method = new StackTrace().GetFrame(1).GetMethod();
                Console.WriteLine("{0}.{1} subscribing", method.ReflectedType.Name, method.Name);
                onSyncFinished += value;
            }
            remove
            {
                var method = new StackTrace().GetFrame(1).GetMethod();
                Console.WriteLine("{0}.{1} unsubscribing", method.ReflectedType.Name, method.Name);
                onSyncFinished -= value;
            }
        }
    }
