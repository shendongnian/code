    public interface ICloneable<T>
    {
      T Clone();
    }
    public class Foo : IEnumerable<IFormattable>
    {
        private List<IFormattable> items = new List<IFormattable>();
    
        public void Add<T>(T value) where T : IFormattable, ICloneable<IFormattable>
        {
            items.Add(value);
        }
    
        public IEnumerator<IFormattable> GetEnumerator()
        {
            items.GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Foo Clone()
        {
            return new Foo { items = new List<IFormattable>(
                items.Cast<ICloneable<IFormattable>>().Select(c=>c.Clone()))
            };
        }
    }
