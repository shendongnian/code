    public class PaddingSetter
    {
        public Padding Value { get; private set; }
        public PaddingSetter()
        {
            Value = new Padding(5);
        }
    }
...
    public void Add(PaddingSetter setter)
    {
        Padding = setter.Value;
    }
