    public class Logging
    { 
        public static void Write(params object[] items)
        {
            Console.WriteLine(string.Join(" ", items));
        }
    }
