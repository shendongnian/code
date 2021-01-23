    public class CloneableList<T> : List<T>, ICloneable<CloneableList<T>>
    {
        public CloneableList<T> Clone()
        {
            throw new InvalidOperationException();
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
