        private static int[] data;          // fix
        private static int Pivot(int left, int right)
        {
            int pivot = data[left];
            while (left <= right)
            {
                while (data[left] < pivot)
                {
                    left++;
                }
    
                while (data[right] > pivot)
                {
                    right--;
                }
    
                if (left <= right)          // fix
                {
                                            // fix deleted 4 lines
                    int temp = data[left];
                    data[left] = data[right];
                    data[right] = temp;
                    left++;                 // fix
                    right--;                // fix
                }
            }
            return right;                   // fix
        }
        private static void QuickSort(int left, int right)
        {
            Shuffle(left, right);
            if (left < right)
            {
                int pivot = Pivot(left, right);
                QuickSort(left,    pivot);  // fix
                QuickSort(pivot+1, right);  // fix
            }
        }
    
        public static void Shuffle(int lo, int hi)
        {
            Random rand = new Random();
            for (int i = lo; i <= hi; i++)
            {
                int r = i + rand.Next(hi + 1 - i);
                int t = data[i]; data[i] = data[r]; data[r] = t;
            }
        }
        static void Main(string[] args)
        {
            data = new int[] { 1, 9, 10, 2, 4, 5, 6, 3, 257, -6 }; // fix
    
            long before = Environment.TickCount;
    
            QuickSort(0, data.Length - 1);
            long after = Environment.TickCount;
    
            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine(data[i]);
            }
            Console.WriteLine(after - before);
        }
