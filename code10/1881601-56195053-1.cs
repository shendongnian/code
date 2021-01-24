    private static readonly Random _random = new Random();
    private static string CreateCode()
    {
        var bytes = new byte[11];
        _random.NextBytes(bytes);
            string s = BitConverter.ToString(bytes).Replace("-", "");
            string result = new StringBuilder(s)
                .Insert(18, '-')
                .Insert(12, '-')
                .ToString();
        return result;
    }
    static void Main(string[] args)
    {
        const int N = 3;
        var codes = new string[N];
        for (int i = 0; i < N; i++) {
            codes[i] = CreateCode();
            Console.WriteLine(codes[i]);
        }
    }
