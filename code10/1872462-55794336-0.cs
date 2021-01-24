    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 344, 334, 200, 188, 39, 981, 33 };
            Console.WriteLine("Array after Recursive Selection Sort: ");
            SelectionSortRecursive(array, 0); // initial recursive call
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
        private static void SelectionSortRecursive(int[] Array, int n) // sorted in ascending order recursively
        {
            if (n >= Array.Length - 1)
                return;
            int min = n;
            for (int i = n + 1; i < Array.Length; i++)
            {
                if (Array[i] < Array[min])
                    min = i;
            }
            swap(Array, n, min);
            SelectionSortRecursive(Array, n + 1);
        }
        public static void swap(int[] Array, int x, int y)
        {
            int temp = Array[x];
            Array[x] = Array[y];
            Array[y] = temp;
        }
    }
