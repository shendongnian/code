        static string LETTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static string NUMBERS = "1234567890";
        static Random rdGen = new Random();
        static Dictionary<string, int> myDic = new Dictionary<string, int>();
        static void WriteTest(int max)
        {
            myDic = new Dictionary<string, int>();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < max; i++)
            {
                string code = LETTERS[rdGen.Next(0, 26)].ToString() + NUMBERS[rdGen.Next(0, 10)].ToString() + LETTERS[rdGen.Next(0, 26)].ToString() + LETTERS[rdGen.Next(0, 26)].ToString();
                if (myDic.ContainsKey(code)) myDic[code]++;
                else
                {
                    myDic[code] = 1;
                }
            }
            sw.Stop();
            Console.WriteLine(max.ToString() + " itérations : " + sw.ElapsedMilliseconds.ToString());
            
        }
