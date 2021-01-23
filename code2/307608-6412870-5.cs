    [LogFile(@"C:\EventLog.txt", true)]
    public class Foo
    {
        readonly int id;
        public Foo(int id)
        {
            this.id = id;
        }
        public int Id { get { return this.id; } }
    }
