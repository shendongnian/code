    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("731478718861993983".InsertChar("-", 4));
        }
    }
    static class Ext
    {
        public static string InsertChar(this string str, string c, int i)
        {
            for (int j = str.Length - i; j >= 0; j -= i)
            {
                str = str.Insert(j, c);
            }
            return str;
        }
    }
