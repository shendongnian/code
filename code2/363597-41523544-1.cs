    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Start.....");
            for ( int i = 0; i  < 10; i++)
            {
                IEnumerable collection;
                Console.WriteLine();
                if (i % 2 == 0)
                { Console.Write("Ints..... ");  
                  collection = new MyCollection<int>(new int[] { 1,2,3 });  }
                else
                { Console.Write("Strings..... ");  
                  collection = new MyCollection<string>(new string[] { "x","y","z" } ); }
                foreach (var item in collection) { Console.Write(item); }
                Console.WriteLine();
            }
            Console.WriteLine(); Console.WriteLine("End....."); Console.ReadLine();
        }
    }
    public class MyCollection<T> : IEnumerable<T>
    {
        private T[] _Tdata;
        public MyCollection4(T[] arrayOfT)
        {
            _Tdata = arrayOfT;
        }
        public IEnumerator<T> GetEnumerator() 
        {
            var listofT = new List<T>(_Tdata);
            return listofT.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
