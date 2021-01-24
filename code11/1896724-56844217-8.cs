    public static void Main()
    {
        A valAsA = A.One | A.Three | A.Four;
        B valAsB = Convert<A, B>(valAsA);  // Should give me "B.Three | B.Four"
        C valAsC = Convert<A, C>(valAsA); // Should give me "C.One | C.Three"
        Console.WriteLine("{0} should equal {1}", valAsB, (B.Three | B.Four));
        Console.WriteLine("{0} should equal {1}", valAsC, (C.One | C.Three));
    }
