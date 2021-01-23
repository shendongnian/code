        public static int[] FewUnique(int uniqueCount, int returnSize)
        {
            Random r = _random;
            int[] values = new int[uniqueCount];
            for (int i = 0; i < uniqueCount; i++)
            {
                values[i] = i;
            }
            int[] array = new int[returnSize];
            for (int i = 0; i < returnSize; i++)
            {
                array[i] = values[r.Next(0, values.Count())];
            }
            return array;
        }
