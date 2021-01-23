    public class CloneableList<T> : List<T>, ICloneable<CloneableList<T>> where T : ICloneable
    {
        public CloneableList<T> Clone()
        {
            var result = new CloneableList<T>();
            result.AddRange(this.Select(item => (T) item.Clone()));
            return result;
        }
        object ICloneable.Clone()
        {
            return ((ICloneable<CloneableList<T>>) this).Clone();
        }
    }
    public interface ICloneable<T> : ICloneable where T : ICloneable<T>
    {
        new T Clone();
    }
