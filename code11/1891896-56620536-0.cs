    class Program
    {
        static List<string> biggestList = new List<string>();
        static void Main(string[] args)
        {
            string str = "abc";
            char[] arr = str.ToCharArray();
            GetPer(arr);
            Console.WriteLine("Complete List:");
            for (int i = 0; i < biggestList.Count; i++)
                Console.WriteLine(biggestList[i]);
            Console.ReadKey();
        }
        private static void Swap(ref char a, ref char b)
        {
            if (a == b) return;
            a ^= b;
            b ^= a;
            a ^= b;
        }
        public static void GetPer(char[] list)
        {
            int x = list.Length - 1;
            GetPer(list, 0, x);
        }
        private static void GetPer(char[] list, int k, int m)
        {
            if (k == m)
            {
                string result = string.Join("", list.ToArray());
                for (int i = 0; i < result.Length; i++)
                {
                    if(!biggestList.Contains(result.Substring(0, i + 1)))
                        biggestList.Add(result.Substring(0, i+1));
                }
            }
            else
            {
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPer(list, k + 1, m);
                    Swap(ref list[k], ref list[i]);
                }
            }
        }
    }
