    public class Qaz
    {
        public void Foo<T>(T item)
        {
            Console.WriteLine(typeof(T).Name);
        }
    }
    public class Bar { }
