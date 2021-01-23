    class Program
    {
        static void Main(string[] args)
        {    
            Container<string> container;
            container = "hello";
        }
    }
    public class Container<T>
    {
        public T Value { get; set; }
        public static implicit operator Container<T>(T val)
        {
            return new Container<T> { Value = val };
        }
    }
