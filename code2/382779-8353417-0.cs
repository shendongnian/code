    public class Program
    {
        private static void Thing(dynamic other)
        {
            Console.WriteLine(other.TheThing);
        }
        private static void Main()
        {
            var things = new { TheThing = "Worked!" };
            Thing(things);
        }
    }
