    class Program
    {
        static void Main(string[] args)
        {
            var myList = new MyList<(int head, int[] tail)> {
        (0, new[] { 1, 2, 3 }),
        (7, new[] { 8, 9 }   ), };
            ref var firstElement = ref myList[0];
            firstElement.head = 99;
            Console.WriteLine("Hello World!");
        }
    }
    public class MyList<T> : IEnumerable
    {
        private T value;
        public ref T this[int index]
        {
            get
            {
                 return ref value;
            }
        }
        public void Add(T i)
        {
            value = i;
        }
        public IEnumerator GetEnumerator() => throw new NotImplementedException();
    }
