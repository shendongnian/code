    public interface INamed : IEquatable<INamed>
    {
        string Name { get;}
    }
    public abstract class NamedItem : INamed
    {
        public abstract string Name { get; }
        public bool Equals(INamed other)
        {
            if(other==null) return false;           
            return Name.Equals(other.Name);
        }
    }
    public class UniqueList<T> : List<T>
        where T : INamed
    {
        public T AddUnique(T item)
        {
            int index = FindIndex((x) => item.Equals(x));
            if (index < 0)
            {
                Add(item);
                return item;
            }
            else
            {
                return this[index];
            }
        }
    }
