    class HasSConstructor
    {
        internal const int Answer = 42;
        static HasSConstructor()
        {
            System.Console.WriteLine("static constructor running");
        }
    }
    
    public class Program
    {
        public static void Main()
        {
            System.Console.WriteLine("The answer is " + HasSConstructor.Answer.ToString());
        }
    }
