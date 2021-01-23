    public static int[] digitArr(int n)
    {
        if (n == 0) return new int[1] { 0 };
    
        var digits = new List<int>();
    
        for (; n != 0; n /= 10)
            digits.Add(n % 10);
    
        var arr = digits.ToArray();
        Array.Reverse(arr);
        return arr;
    }
