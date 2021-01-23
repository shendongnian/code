    public class Foo
    {
        private readonly List<int> list = new List<int>();
        private readonly object locker = new object();
    
        public void SomeCommand(Bar bar)
        {
            lock (this.locker)
            {
                this.list.Add(..);
            }
        }
    
        public Baz SomeQuery()
        {
            lock (this.locker)
            {
                this.list.Select(...);
            }
        }
    }
