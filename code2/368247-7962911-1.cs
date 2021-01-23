    // Warning: this scans the input multiple times!
    // Rewriting the code to only use a single scan is left as an exercise
    // for the reader.
    public static class DistinctCountExtenstion
    {
        public static int DistinctCount(this IEnumerable<int> values)
        {
            int min = values.Min();
            int max = values.Max();
            int[] bitarray = new int[(max - min + 31) / 32];
            foreach (int value in values)
            {
                int i = (value - min) / 32;
                int j = (value - min) % 32;
                bitarray[i] |= (1 << j);
            }
    
            int count = 0;
            for (int i = 0; i < bitarray.Length; ++i)
            {
                int bits = bitarray[i];
                while (bits > 0)
                {
                    count += bits % 2;
                    bits >>= 1;
                }
            }
            return count;
        }
    }
