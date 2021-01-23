    public interface ISnaphot<T>
    {
        T TakeSnapshot();
    }
    public class Immutable<T> where T : ISnaphot<T>
    {
        private readonly T _item;
        public T Copy { get { return _item.TakeSnapshot(); } }
        public Immutable(T item)
        {
            _item = item.TakeSnapshot();
        }
    }
