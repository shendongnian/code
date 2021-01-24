        class Program
        {
            public static void Main()
            {
                //int[] x = new int[] { 4, 4, 4, 3, 3, 3, 2, 2, 2, 1, 1, 1 };
                int[] x = new int[] { 1, 2, 2 };
                PermutationTool<int> tool = new PermutationTool<int>(printArr);
                tool.PermutationsWithoutDuplicates(x);
                Console.ReadLine();
            }
            static void printArr(int[] a)
            {
                for (int i = 0; i < a.Length; i++)
                    Console.Write(a[i] + " ");
                Console.WriteLine();
            }
        }
        class PermutationTool<T> where T : IComparable
        {
            T[] _uniquekeys;
            Action<T[]> _callback;
            public PermutationTool(Action<T[]> callback)
            {
                _callback = callback;
            }
            public void PermutationsWithoutDuplicates(T[] a)
            {
                HashSet<T> hs = new HashSet<T>(a);
                List<T> sortedlist = new List<T>(hs.ToArray());
                Dictionary<T, int> map = new Dictionary<T, int>();
                sortedlist.Sort();
                _uniquekeys = sortedlist.ToArray();
                for (int i = 0; i < _uniquekeys.Length; i++)
                {
                    map.Add(_uniquekeys[i], i);
                }
                int[] a2 = new int[a.Length];
                for (int i = 0; i < a.Length; i++)
                    a2[i] = map[a[i]];
                int[] next_fixable = new int[_uniquekeys.Length];
                Dictionary<int, int> count = new Dictionary<int, int>(_uniquekeys.Length);
                for (int i = 0; i < _uniquekeys.Length; i++)
                {
                    count.Add(i, 0);
                }
                int[] int_number = new int[a2.Length];
                for (int i = 0; i < a2.Length; i++)
                {
                    int_number[i] = count[a2[i]];
                    count[a2[i]] += 1;
                }
                hs.Clear();
                sortedlist.Clear();
                count.Clear();
                if (_uniquekeys.Length != a.Length)
                    PermutationWithoutDuplicates(a2, next_fixable, int_number, 0, a2.Length);
                else
                    HeapPermutation(a2, a2.Length); //all permutation are unique, switch to the faster heap algorithm
            }
            private void PermutationWithoutDuplicates(int[] a, int[] next_fixable, int[] int_number, int begin, int end)
            {
                if (end == begin + 1)
                    FoundPermutation(a);
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
                            PermutationWithoutDuplicates(a, next_fixable, int_number, begin + 1, end);
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
            private void HeapPermutation(int[] a, int size)
            {
                if (size == 1)
                    FoundPermutation(a);
                for (int i = 0; i < size; i++)
                {
                    HeapPermutation(a, size - 1);
                    if (size % 2 == 1)
                    {
                        int temp = a[0];
                        a[0] = a[size - 1];
                        a[size - 1] = temp;
                    }
                    else
                    {
                        int temp = a[i];
                        a[i] = a[size - 1];
                        a[size - 1] = temp;
                    }
                }
            }
            private void FoundPermutation(int[] a)
            {
                if (_callback != null)
                {
                    T[] p = new T[a.Length];
                    for (int i = 0; i < a.Length; i++)
                        p[i] = _uniquekeys[a[i]];
                    _callback(p);
                }
            }
        }
    
