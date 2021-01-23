    public interface ICloneable<T>
    {
      T Clone();
    }
    public class FretPiece : IEnumerable<IFormattable>, ICloneable<FretPiece>
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
        public FretPiece Clone()
        {
            return new FretPiece { items = new List<IFormattable>(
                items.Cast<ICloneable<IFormattable>>().Select(c=>c.Clone()))
            };
        }
    }
