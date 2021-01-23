    public class SerialComparer : IComparer<T>
    {
        public int Compare(string x, string y)
        {
            // If x == y:
            //   return 0
            // If x > y:
            //   return 1
            // Else:
            //   return -1
        }
    }
    public static void Main(string[] args)
    {
       var x = "56AAA7105A25"; 
       var y = "56AAA71064D6";
       var comparer = new SerialComparer();
       if (comparer.Compare(x, y) > 0)
       {
           Console.WriteLine("{0} is greater than {1}", x, y);
       }
       else
       {
           Console.WriteLine("{0} is not greater than {1}", x, y);
       }
    }
