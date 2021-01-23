    public static class Sort
    {
        public static int Threshold = 150; 
        public static void InsertionSort(int[] array, int from, int to)
        {
            // ...
        }
        static void Swap(int[] array, int i, int j)
        {
            // ...
        }
        static int Partition(int[] array, int from, int to, int pivot)
        {
            // ...
        }
        public static void ParallelQuickSort(int[] array)
        {
           ParallelQuickSort(array, 0, array.Length, 
                (int) Math.Log(Environment.ProcessorCount, 2) + 4);
        }
        static void ParallelQuickSort(int[] array, int from, int to, int depthRemaining)
        {
            if (to - from <= Threshold)
            {
                InsertionSort(array, from, to);
            }
            else
            {
                int pivot = from + (to - from) / 2; // could be anything, use middle
                pivot = Partition(array, from, to, pivot);
                if (depthRemaining > 0)
                {
                    Parallel.Invoke(
                        () => ParallelQuickSort(array, from, pivot, depthRemaining - 1),
                        () => ParallelQuickSort(array, pivot + 1, to, depthRemaining - 1));
                }
                else
                {
                    ParallelQuickSort(array, from, pivot, 0);
                    ParallelQuickSort(array, pivot + 1, to, 0);
                }
            }
        }
    }
