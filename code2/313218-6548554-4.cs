    public class Condition
    {
        public Func<bool> Match { get; set; }
        public Action Execute { get; set; }
    }
