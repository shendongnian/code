    class Program
    {
        static void Main()
        {
            var a = new Option<int>.Some(1);
            var result = a.FlatMap<int>(i => { Console.WriteLine(i); return new Option<int>.Some(i + 1); })
             .FlatMap<int>(i => { Console.WriteLine(i); return new Option<int>.Some(i); })
             .FlatMap<int>(i => { Console.WriteLine(i); return new Option<int>.None(); })
             .FlatMap<int>(i => { Console.WriteLine(i); return new Option<int>.Some(i); });
            switch (result)
            {
                case Option<int>.Some some:
                    Console.WriteLine("I got Some!");
                    break;
                case Option<int>.None none:
                    Console.WriteLine("I got None!");
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
    public abstract class Option<T>
    {
        public class Some : Option<T>
        {
            public Some(T data)
            {
                Data = data;
            }
            public T Data;
        }
        public class None : Option<T> { }
        public Option<T> FlatMap<T>(Func<T, Option<T>> action)
        {
            switch (this)
            {
                case Option<T>.Some some:
                    return action(some.Data);
                case Option<T>.None none:
                    return none;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
