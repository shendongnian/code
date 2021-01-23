    public class Test
    {
        public static int Add(int i1, int i2)
        {
            return i1 + i2;
        }
        public static int Add(params int[] ints)
        {
            int sum = 0;
            foreach (int i in ints)
                sum += i;
            return sum;
        }
    }
