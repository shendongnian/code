        static void Main(string[] args)
        {
            Dictionary<string, List<long>> dic = new Dictionary<string, List<long>>();
            dic["First"] = new List<long>();
            dic["Second"] = new List<long>();
            dic["Third"] = new List<long>();
            for (int i = 0; i < 500; i++)
            {
                int[] array = GetRandomArray();
                Stopwatch stopWacth = new Stopwatch();
                stopWacth.Restart();
                int n1 = FindMin(array);
                stopWacth.Stop();
                long firstTicks = stopWacth.ElapsedTicks;
                dic["First"].Add(firstTicks);
                stopWacth.Restart();
                int n2 = AnotherFindMin(array);
                stopWacth.Stop();
                long secondTick = stopWacth.ElapsedTicks;
                dic["Second"].Add(secondTick);
                stopWacth.Restart();
                int n3 = array.Min();
                stopWacth.Stop();
                long thirdTick = stopWacth.ElapsedTicks;
                dic["Third"].Add(thirdTick);
                Console.WriteLine("first tick : {0}, second tick {1}, third tick {2} ", firstTicks, secondTick, thirdTick);
            }
            Console.WriteLine("first tick : {0}, second tick {1}, third tick {2} ", dic["First"].Average(), dic["Second"].Average(), dic["Third"].Average());
            Console.ReadLine();
        }
        public static int[] GetRandomArray()
        {
            int[] retVal = new int[1000000];
            Random r = new Random();
            for (int i = 0; i < 1000000; i++)
            {
                retVal[i] = r.Next(1000000000);
            }
            return retVal;
        }
        public static int FindMin(int[] arr)
        {
            switch (arr.Length)
            {
                case 0: throw new InvalidOperationException();
                case 1: return arr[0];
                case 2: return Math.Min(arr[0], arr[1]);
                default:
                    int min = arr[0];
                    for (int i = 1; i < arr.Length; i++)
                    {
                        if (arr[i] < min) min = arr[i];
                    }
                    return min;
            }
        }
        public static int AnotherFindMin(int[] arr)
        {
            if (arr.Length > 0)
            {
                int min = arr[0];
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] < min) min = arr[i];
                }
                return min;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
    // revised test by Marc (see comments discussion)
    static class Test {
        static void Main(string[] args)
        {
            Dictionary<string, List<long>> dic = new Dictionary<string, List<long>>();
    
            dic["First"] = new List<long>();
            dic["Second"] = new List<long>();
            dic["Third"] = new List<long>();
    
            const int OUTER_LOOP = 500, INNER_LOOP = 500000;
            for (int arrSize = 1; arrSize <= 3; arrSize++)
            {
                for (int i = 0; i < OUTER_LOOP; i++)
                {
                    int[] array = GetRandomArray(arrSize);
                    Stopwatch stopWacth = Stopwatch.StartNew();
                    for (int j = 0; j < INNER_LOOP; j++)
                    {
                        int n1 = FindMin(array);
                    }
                    stopWacth.Stop();
                    long firstTicks = stopWacth.ElapsedTicks;
                    dic["First"].Add(firstTicks);
    
                    stopWacth = Stopwatch.StartNew();
                    for (int j = 0; j < INNER_LOOP; j++)
                    {
                        int n2 = AnotherFindMin(array);
                    }
                    stopWacth.Stop();
                    long secondTick = stopWacth.ElapsedTicks;
                    dic["Second"].Add(secondTick);
    
                    stopWacth = Stopwatch.StartNew();
                    for (int j = 0; j < INNER_LOOP; j++)
                    {
                        int n3 = array.Min();
                    }
                    stopWacth.Stop();
                    long thirdTick = stopWacth.ElapsedTicks;
                    dic["Third"].Add(thirdTick);
    
                    //Console.WriteLine("{3}: switch : {0}, 0-check {1}, Enumerable.Min {2} ", firstTicks, secondTick, thirdTick, arrSize);
                }
    
                Console.WriteLine("{3}: switch : {0}, 0-check {1}, Enumerable.Min {2} ", dic["First"].Average(), dic["Second"].Average(), dic["Third"].Average(), arrSize);
            }
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    
    
        public static int[] GetRandomArray(int size)
        {
            int[] retVal = new int[size];
            Random r = new Random();
            for (int i = 0; i < retVal.Length; i++)
            {
                retVal[i] = r.Next(1000000000);
            }
            return retVal;
        }
    
        public static int FindMin(int[] arr)
        {
            switch (arr.Length)
            {
                case 0: throw new InvalidOperationException();
                case 1: return arr[0];
                case 2: return arr[0] < arr[1] ? arr[0] : arr[1];
                default:
                    int min = arr[0];
                    for (int i = 1; i < arr.Length; i++)
                    {
                        if (arr[i] < min) min = arr[i];
                    }
                    return min;
            }
        }
    
        public static int AnotherFindMin(int[] arr)
        {
            if (arr.Length > 0)
            {
                int min = arr[0];
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] < min) min = arr[i];
                }
                return min;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
