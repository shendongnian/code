    public enum NumberWords
    {
        zero,
        one,
        two,
        three,
        four,
        five
    }
    public static class IntExtensions
    {
        public static string ToWord(this int input)
        {
            return ((NumberWords)input).ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(((NumberWords)5).ToString());
    
            Console.WriteLine(0.ToWord());
            Console.WriteLine(1.ToWord());
            Console.WriteLine(2.ToWord());
            Console.WriteLine(123.ToWord());
    
            Console.ReadLine();
        }
    }
