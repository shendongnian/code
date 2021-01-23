    public static class StringExtensions
    {
        // I'd use one or the other of these methods, and whichever one you choose, 
        // rename it to SplitAt()
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Tuple<string, string> TupleSplitAt(this string text, int index) => 
            Tuple.Create<string, string>(text.Substring(0, index), text.Substring(index));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string[] ArraySplitAt(this string text, int index) => 
            new string[] { text.Substring(0, index), text.Substring(index) };
    }
    
    public static class Program
    {
        public static void Main()
        {
        	Tuple<string, string> stringsTuple = "leftright".TupleSplitAt(4);
        	Console.WriteLine("Tuple method");
            Console.WriteLine(stringsTuple.Item1);
        	Console.WriteLine(stringsTuple.Item2);
    
            Console.WriteLine();
    
            Console.WriteLine("Array method");
        	string[] stringsArray = "leftright".ArraySplitAt(4);
            Console.WriteLine(stringsArray[0]);
        	Console.WriteLine(stringsArray[1]);
        }
    }
