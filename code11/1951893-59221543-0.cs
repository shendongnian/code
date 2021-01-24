    public class Transformer
    {
        private readonly List<int> items = new List<int>();
        public IEnumerable<int> Items => items.ToList();
        public void Add(int item) => items.Add(items.LastOrDefault() + item);
        public void Add(IEnumerable<int> input)
        {
            foreach (var item in input) Add(item);
        }
        public override string ToString()
        {
            return string.Join(", ", Items);
        }
    }
