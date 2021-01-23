    public struct Tuple<A, B>
    {
       public readonly A Item1;
       public readonly B Item2;
       public Tuple(A a, B b) { Item1 = a; Item2 = b; }
    }
    public static class Tuple
    {
       public static Tuple<A,B> Create<A,B>(A a, B b) { return new Tuple<A,B>(a,b); }
    }
