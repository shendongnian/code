    public class Foo : IEnumerable<IFormattable>
    {
        private List<IFormattable> items = new List<IFormattable>();
    
        public void Add<T>(T value) where T : IFormattable, ICloneable
        {
            items.Add(value);
        }
    
        public IEnumerator<IFormattable> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
