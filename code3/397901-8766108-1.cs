    public class Foo
    {
        private readonly List<int> list = new List<int>();
        private readonly object locker = new object();
    
        public void SomeCommand(Bar bar)
        {
            lock (this.locker)
            {
                // do something here?
                this.list.Add(..);
                // do something here?
            }
        }
    
        public Baz SomeQuery()
        {
            lock (this.locker)
            {
                // do something here?
                this.list.Select(...);
                // do something here?
            }
        }
    }
