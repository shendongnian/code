        static void Main(string[] args)
        {
            int[][][] x = new int[][][]
            {
                new int[][]
                {
                    new int [] { 1, 2, 3, 4 },
                    new int [] { 5, 6 },
                    new int [] { 7 }
                },
                new int[][]
                {
                    new int [] { 8 },
                    new int [] { 9, 10 },
                    new int [] { 11, 12, 13, 14 }
                }
            };
            DeepEnumerateArray(x);
            Console.ReadLine();
        }
        static void DeepEnumerateArray(Array x)
        {
            if (x.Length == 0)
                return;
            object first = x.GetValue(0);
            if (first is Array)
            {
                foreach (Array y in x)
                    DeepEnumerateArray(y);
            }
            else
            {
                foreach (object z in x)
                    Console.WriteLine(z);
            }
        }
