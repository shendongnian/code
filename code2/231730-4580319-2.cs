    public static int[] ToDigitArray(int n)
    {
        int[] result = new int[GetDigitArrayLength(n)];
        for (int i = 0; i < result.Length; i++)
        {
            result[result.Length - i - 1] = n % 10;
            n /= 10;
        }
        return result;
    }
    private static int GetDigitArrayLength(int n)
    {
        if (n == 0)
            return 1;
        return 1 + (int)Math.Log10(n);
    }
