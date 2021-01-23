    class Program
    {
        // this method is not called directly
        // but it is public so it is found by reflection
        public static IEnumerable<U> EntryIteratorBlock<T, U>(
            IEnumerable<T> source, Func<object, bool> selector)
        {
            TypeConverter tc = new TypeConverter();
            foreach (T item in source)
                if (selector(item))
                    yield return (U)tc.ConvertTo(item, typeof(U));
        }
        static IEnumerable CreateIterator(
            // these are the type parameters of the iterator block to create
            Type sourceType, Type destType,
            // these are the parameters to the iterator block being created
            IEnumerable source, Func<object, bool> selector)
        {
            return (IEnumerable) typeof(Program)
                .GetMethod("EntryIteratorBlock")
                .MakeGenericMethod(sourceType, destType)
                .Invoke(null, new object[] { source, selector });
        }
        static void Main(string[] args)
        {
            // sample code prints "e o w o"
            foreach (var i in CreateIterator(typeof(char), typeof(string),
                              "Hello, world", c => ((char)c & 1) == 1))
                Console.WriteLine(i);
        }
    }
