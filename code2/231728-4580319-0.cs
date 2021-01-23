    public static int[] ToDigitArray(int i)
    {
        List<int> result = new List<int>();
        while (i != 0)
        {
            result.Add(i % 10);
            i /= 10;
        }
        return result.Reverse().ToArray();
    }
