    public interface IIndex<T1, T2>
    {
        T2 this[T1 key] { get; set; }
    }
    
    internal class DoubleIndexer<T1, T2> : IIndex<T1, T2>
    {
        public T1 this[T2 key]
        {
            get => default;
            set { Console.WriteLine($"T1 this[T2 key]: {value}"); }
        }
    
        T2 IIndex<T1, T2>.this[T1 key]
        {
            get => default;
            set { Console.WriteLine($"T2 IIndex<T1, T2>.this[T1 key]: {value}"); }
        }
    }
