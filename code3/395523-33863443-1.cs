    namespace preparation
    {
      public  class Program
        {
          public static void swap(ref int lhs,ref int rhs)
          {
              int temp = lhs;
              lhs = rhs;
              rhs = temp;
          }
              static void Main(string[] args)
            {
                int a = 10;
                int b = 80;
              
      Console.WriteLine("a is before sort " + a);
                Console.WriteLine("b is before sort " + b);
                swap(ref a, ref b);
                Console.WriteLine("");
                Console.WriteLine("a is after sort " + a);
                Console.WriteLine("b is after sort " + b);  
            }
        }
    }
