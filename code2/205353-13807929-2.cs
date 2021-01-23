    static void Main(string[] args) {
        TestOptional("A");
        TestOptional("A", 1);
        TestOptional("A", 2, "C1", "C2", "C3"); 
        Console.ReadLine();
    }
    public static void TestOptional(string A, int B = 0, params string[] C) {
        Console.WriteLine(A);
        Console.WriteLine(B.ToString());
        Console.WriteLine(C.Join(", "));
    }
