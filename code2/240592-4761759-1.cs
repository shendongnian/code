public static class Functional
{
    public static Func&lt;TResult&gt; Lambda&lt;TResult&gt;(Func&lt;TResult&gt; func)
    {
        return func;
    }
    public static Func&lt;T, TResult&gt; Lambda&lt;T, TResult&gt;(Func&lt;T, TResult&gt; func)
    {
        return func;
    }
    public static Func&lt;T1, T2, TResult&gt; Lambda&lt;T1, T2, TResult&gt;(Func&lt;T1, T2, TResult&gt; func)
    {
        return func;
    }
}
