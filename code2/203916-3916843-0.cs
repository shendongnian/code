    Program.cs
    ----------
    class Program
    {
        static void Main()
        {
            House.said();
            House.saidAgain();
        }
    }
    House-said.cs
    -------------
    public static partial class House
    {
        public static void said()
        {
            Console.Write("fatty");
            Console.ReadLine();
        }
    }
    House-saidAgain.cs
    ------------------
    public static partial class House
    {
        public static void saidAgain()
        {
            Console.Write("fattyAgain");
            Console.ReadLine();
        }
    }
