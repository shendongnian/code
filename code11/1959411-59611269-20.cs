    public static bool IsEqualTo0<NumA, A>(A n) where NumA : struct, Num<A>, Eq<A> =>
        default(NumA).IsEqualTo(n, default(NumA).Zero);
    public static bool IsEqualTo1<NumA, A>(A n) where NumA : struct, Num<A>, Eq<A> =>
        default(NumA).IsEqualTo(n, default(NumA).One);
    public static A Subtract1<NumA, A>(A n) where NumA : struct, Num<A>, Eq<A> =>
        default(NumA).Subtract(n, default(NumA).One);
    public static A Subtract2<NumA, A>(A n) where NumA : struct, Num<A>, Eq<A> =>
        Subtract1<NumA, A>(Subtract1<NumA, A>(n));
    public static A Fibonacci<NumA, A>(A n) where NumA : struct, Num<A>, Eq<A> =>
        IsEqualTo0<NumA, A>(n) || IsEqualTo1<NumA, A>(n)
            ? n
            : Fibonacci<NumA, A>(default(NumA).Add(
                                    Subtract1<NumA, A>(n), 
                                    Subtract2<NumA, A>(n)));
