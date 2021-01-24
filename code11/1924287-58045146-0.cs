    public class Program
    {
        public static void Main(string[] args)
        {
            Check method1 = new Check(1);
            Check method2 = new Check(2);
        }
    }
    public class Check
    {
        public Check(int x)
        {
            this.GetType().GetMethod("Method" + x).Invoke(this, null); 
        }
        public void Method1()
        {
            Console.WriteLine("Method 1");
        }
        public void Method2()
        {
            Console.WriteLine("Method 2");
        }
    }
