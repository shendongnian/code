    public class Program
    {
            public static void Main()
            {
              Console.WriteLine(MyFunc(1, 2, 3, 4));
            }
    
    
            private int MyFunc(int a, int b, int c, int d)
            {
                var str = new List<int>() { a, b, c, d};
    
               return str.Aggregate((x, y) => int.Parse(x.ToString() + y.ToString()));
            }
    }
