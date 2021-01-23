    public interface ICovariantList<out T>
    {
        T this[int index] { get; }
        //...
    }
    public interface IContravariantList<in T>
    {
        T this[int index] { set; }
        void Add(T item);
        //...
    }
    public class SomeList<T> : ICovariantList<T>, IContravariantList<T>
    {
        //...
    }
