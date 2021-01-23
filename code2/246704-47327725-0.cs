        public int smallestValue(int[] values)
        {
            int smallest = int.MaxValue;
            for (int i = 0; i < values.Length; i++)
            {
                smallest = (values[i] < smallest ? values[i] : smallest);
            }
            return smallest;
        }
        public static int largestvalue(int[] values)
        {
            int largest = int.MinValue;
            for (int i = 0; i < values.Length; i++)
            {
                largest = (values[i] > largest ? values[i] : largest);
            }
            return largest;
        }
