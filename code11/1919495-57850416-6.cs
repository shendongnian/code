class ClassA
{
    public static string A = "A";
}
And to use it:
    using StaticClassA = ConsoleApp1.ClassA;
    class Program
    {
        static void Main(string[] args)
        {
            string a = StaticClassA.A;
        }
    }
Not too much to gain though, but it might ease your naming a little.
Another (somewhat cooler) option is a `static using`:
    using static ConsoleApp1.StaticClassA;
    class Program
    {
        static void Main(string[] args)
        {
            string a = A;
        }
    }
