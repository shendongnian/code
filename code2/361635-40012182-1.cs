    public static void Main(string[] args)
    {
        IntegerList = new List<int> { 1, 2, 3, 4 };
    
        PrintAllCombination(default(int), default(int));
    }
    
    public static List<int> IntegerList { get; set; }
    
    public static int Length { get { return IntegerList.Count; } }
    
    public static void PrintAllCombination(int position, int prefix)
    {
        for (int i = position; i < Length; i++)
        {
            Console.WriteLine(prefix * 10 + IntegerList[i]);
            PrintAllCombination(i + 1, prefix * 10 + IntegerList[i]);
        }
    
    }
