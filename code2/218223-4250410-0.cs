    public static void Main()
    {
        var c1 = new Class1() { A = "apahaa", B = null };
        var c2 = new Class1() { A = "abacaz", B = null };
        Console.WriteLine(c1.Equals(c2));
    }
