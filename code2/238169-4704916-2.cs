    public static void Main()
    {
        Action a = MeaningfullyNamedMethod;
        a();
    }
    static void MeaningfullyNamedMethod()
    {
        Console.WriteLine(MethodInfo.GetCurrentMethod().Name);
    }
