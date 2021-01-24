    public interface IDirectIndex<T1, T2>
    {
        T2 this[T1 key] { get; set; }
    }
    
    public interface IInvertedIndex<T1, T2>
    {
        T1 this[T2 key] { get; set; }
    }
    
    internal class DoubleIndexer<T1, T2> : IDirectIndex<T1, T2>, IInvertedIndex<T1, T2>
    {
        T2 IDirectIndex<T1, T2>.this[T1 key]
        {
            get => default;
            set { Console.WriteLine($"T2 IDirectIndex<T1, T2>.this[T1 key]: {value}"); }
        }
    
        T1 IInvertedIndex<T1, T2>.this[T2 key]
        {
            get => default;
            set { Console.WriteLine($"T1 IInvertedIndex<T1, T2>.this[T2 key]: {value}"); }
        }
    }
