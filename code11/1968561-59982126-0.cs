        public static void Main()
        {
            //int[] x = new int[]{1,2,2,3,4,4,5,1,2,2};
            int[] x = new int[] { 1, 2, 2 };
            PermutationsWithoutDuplicates(x);
            Console.ReadLine();
        }
        static void printArr(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
                Console.Write(a[i] + " ");
            Console.WriteLine();
        }
        public static void PermutationsWithoutDuplicates(int[] a)
        {
            HashSet<int> hs = new HashSet<int>(a);
            int[] uniquekeys = hs.ToArray();
            Dictionary<int, int> next_fixable = new Dictionary<int, int>(uniquekeys.Length);
            Dictionary<int, int> count = new Dictionary<int, int>(uniquekeys.Length);
            foreach (int i in uniquekeys)
            {
                next_fixable.Add(i, 0);
                count.Add(i, 0);
            }
 
            int[] int_number = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                int_number[i] = count[a[i]];
                count[a[i]] += 1;
            }
            Permute(a, next_fixable, int_number, 0, a.Length);
        }
        static void Permute(int[] a, Dictionary<int, int> next_fixable, int[] int_number, int begin, int end)
        {
            if (end == begin + 1)
                printArr(a);
            else
            {
                for (int i = begin; i < end; i++)
                {
                    if (next_fixable[a[i]] == int_number[i])
                    {
                        next_fixable[a[i]] += 1;
                        // swap
                        int temp = int_number[begin];
                        int_number[begin] = int_number[i];
                        int_number[i] = temp;
                        // swap
                        temp = a[begin];
                        a[begin] = a[i];
                        a[i] = temp;
                        Permute(a, next_fixable, int_number, begin + 1, end);
                        // swap
                        temp = a[begin];
                        a[begin] = a[i];
                        a[i] = temp;
                        // swap
                        temp = int_number[begin];
                        int_number[begin] = int_number[i];
                        int_number[i] = temp;
                        next_fixable[a[i]] -= 1;
                    }
                }
            }
        }
