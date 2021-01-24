    public class Item<T>
    {
        public T Value { get; set; }
        public int Count  { get; set; }
        public override string ToString()
        {
            return $"{Value} * {Count}";
        }
    }
