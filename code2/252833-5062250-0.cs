    static class ByteArrayRocks
    {
        public static bool Contains(this byte[] self, byte[] candidate)
        {
            if (IsEmptyLocate(self, candidate))
                return false;
            for (int i = 0; i < self.Length; i++)
            {
                if (IsMatch(self, i, candidate))
                    return true;
            }
            return false;
        }
        static bool IsMatch(byte[] array, int position, byte[] candidate)
        {
            if (candidate.Length > (array.Length - position))
                return false;
            for (int i = 0; i < candidate.Length; i++)
                if (array[position + i] != candidate[i])
                    return false;
            return true;
        }
        static bool IsEmptyLocate(byte[] array, byte[] candidate)
        {
            return array == null
                    || candidate == null
                    || array.Length == 0
                    || candidate.Length == 0
                    || candidate.Length > array.Length;
        }
    }
    class Program
    {
        static void Main()
        {
            var data = new byte[] { 23, 36, 43, 76, 125, 56, 34, 234, 12, 3, 5, 76, 8, 0, 6, 125, 234, 56, 211, 122, 22, 4, 7, 89, 76, 64, 12, 3, 5, 76, 8, 0, 6, 125 };
            var pattern = new byte[] { 12, 3, 5, 76, 8, 0, 6, 125,11 };
            Console.WriteLine(data.Contains(pattern));
            Console.ReadKey();
        }
    }
