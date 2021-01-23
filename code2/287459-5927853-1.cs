    struct Test { public decimal value; }
    static void Main() {
        var t1 = new Test() { value = 1.0m };
        var t2 = new Test() { value = 1.00m };
        if (t1.GetHashCode() != t2.GetHashCode())
            Console.WriteLine("gack!");
    }
