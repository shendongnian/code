    static class ReverseString
    {
        const string stringToReverse = "abcdex.dfkjvhw4o5i8yd,vfjhe4iotuwyflkcjadhrlniqeuyfmln mclf8yuertoicer,tpoirsd,kfngoiw5r8t7ndlrgjhfg";
        public static string TestStringBuilder()
        {
            var sb = new StringBuilder(stringToReverse);
            for (int i = 0, j = sb.Length - 1; i < sb.Length / 2; i++, j--) {
                char temp = sb[i];
                sb[i] = sb[j];
                sb[j] = temp;
            }
            return sb.ToString();
        }
        // By Mendhak
        public static string TestArrayReverse()
        {
            char[] arr = stringToReverse.ToString().ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        public static void Compare()
        {
            string result1 = TestStringBuilder();
            string result2 = TestArrayReverse();
            Console.WriteLine($"Are result1 and 2 equal?   {result1 == result2}");
            Measure("StringBuilder", TestStringBuilder);
            Measure("Array.Reverse", TestArrayReverse);
            Console.ReadKey();
        }
        public static void Measure(string method, Func<string> sut)
        {
            const int NTests = 1000000;
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < NTests; i++) {
                sut();
            }
            stopWatch.Stop();
            Console.WriteLine($"{method} = {stopWatch.ElapsedMilliseconds} ms");
        }
    }
