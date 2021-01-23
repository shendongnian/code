    public static class Ex
    {
        public static List<char> Rotate(this List<char> c, int i)
        {
            i %= c.Count;
            return c.Skip(i).Concat(c.Take(i)).ToList();
        }
    }
    
    class Program
    {
        static void Main()
        {
            List<char> chars = new List<char>();
    
            for (int i = 65; i < 75; ++i)
            {
                chars.Add((char)i);
            }
    
            var r1 = chars.Rotate(10); // A B C D E F G H I J
            var r2 = chars.Rotate(1); // B C D E F G H I J A
            var r3 = chars.Rotate(101); // B C D E F G H I J A
            var r4 = chars.Rotate(102); // C D E F G H I J A B
        
            Console.ReadLine();
        }
    }
