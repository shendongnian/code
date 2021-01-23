    public interface I
    {
        IEnumerable<int> F { get; set; }
    }
    public class C:I
    {
        private List<int> f;
        public IEnumerable<int> F
        {
            get { return f; }
            set { f = new List<int>(value); }
        }
    }
