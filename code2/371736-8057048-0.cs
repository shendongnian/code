    public class Test
    {
        public static void Blah<T>(Action<T> blah)
        {
        }
    
        public static void Main()
        {
            Blah(x => { Console.LineWrite(x); });
        }
    }
