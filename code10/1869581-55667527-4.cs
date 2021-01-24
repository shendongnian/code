    static class ReverseString
    {
        const string stringToReverse = "abcdex.dfkjvhw4o5i8yd,vfjhe4iotuwyflkcjadhrlniqeuyfmln mclf8yuertoicer,tpoirsd,kfngoiw5r8t7ndlrgjhfg";
        public static string Test()
        {
            var sb = new StringBuilder(stringToReverse);
            for (int i = 0, j = sb.Length - 1; i < sb.Length / 2; i++, j--) {
                char temp = sb[i];
                sb[i] = sb[j];
                sb[j] = temp;
            }
            return sb.ToString();
        }
        public static string TestMendhak()
        {
            char[] arr = stringToReverse.ToString().ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        public static void Compare()
        {
            const int NTests = 1000000;
            string result1 = Test();
            string result2 = TestMendhak();
            Console.WriteLine($"Are result1 and 2 equal?   {result1 == result2}");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < NTests; i++) {
                Test();
            }
            stopWatch.Stop();
            Console.WriteLine($"StringBuilder = {stopWatch.ElapsedMilliseconds} ms");
            stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < NTests; i++) {
                TestMendhak();
            }
            stopWatch.Stop();
            Console.WriteLine($"Mendhak = {stopWatch.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }
    }
