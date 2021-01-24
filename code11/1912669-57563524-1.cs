    public static void Main()
    {
        //Console.WriteLine(GetLine(GetNum()));
        Console.WriteLine(GetNum().CallDeconstructed(GetLine));
    }
    public static (int, string) GetNum() => (5, "five");
    public static string GetLine(int n, string s) => $"{n} {s}";
