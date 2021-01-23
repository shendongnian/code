    class Program
    {
        static void Main(string[] args)
        {
            Action<int> myAction = new Action<int>(DoSomething);
            myAction.Invoke(123);           // Prints out "123"
            Func<int, double> myFunc = new Func<int, double>(CalcualteSomething);
            Console.WriteLine(myFunc(5));   // Prints out "2.5"
        }
        static void DoSomething(int i)
        {
            Console.WriteLine(i);
        }
        static double CalcualteSomething(int i)
        {
            return (double)i/2;
        }
    }
