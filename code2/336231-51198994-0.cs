    public static class StringExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (string left, string right) SplitAt(this string text, int index) => 
            (text.Substring(0, index), text.Substring(index));
    }
    public static class Program
    {
        public static void Main()
        {
            var (left, right) = "leftright".SplitAt(4);
            Console.WriteLine(left);
            Console.WriteLine(right);
        }
    }
