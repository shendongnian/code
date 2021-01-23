    static void Main(string[] args) {
        TestOptional("A");
        TestOptional("A", "B");
        TestOptional("A", "{0}, {1} , {2}", "C1", "C2", "C3"); 
        Console.ReadLine();
    }
    public static void TestOptional(string A, string B = null, params object[] C) {
        Console.WriteLine(A);
        if (B != null) {
            Console.WriteLine(B, C);
        }
    }
