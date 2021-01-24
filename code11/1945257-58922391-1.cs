    static void A(int num)
    {
        Console.Write(GetCurrentMethod() + " -> ");
        if (num > 0)
            B(num);
        else
            C(num);
    }
    static void B(int num)
    {
        Console.Write(GetCurrentMethod() + " -> ");
        if (num < 5)
            D(num);
        else
            E(num);
    }
    static void C(int num)
    {
        Console.Write(GetCurrentMethod() + " -> ");
        if (num < -10)
            F(num);
        else
            G(num);
    }
    static void D(int num)
    {
        Console.WriteLine(GetCurrentMethod() + " -> ");
    }
    static void E(int num)
    {
        Console.WriteLine(GetCurrentMethod() + " -> ");
    }
    static void F(int num)
    {
        Console.WriteLine(GetCurrentMethod() + " -> ");
    }
    static void G(int num)
    {
        Console.WriteLine(GetCurrentMethod() + " -> ");
    }
