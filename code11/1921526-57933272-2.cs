    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> enumerable = new List<string> { "a", "b", "c" };
            foreach (string element in enumerable)
            {
                object item = element;
                item = "d"; 
            }
            IEnumerator enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                object item = enumerator.Current;
                item = "d";
            }
        }
    }
