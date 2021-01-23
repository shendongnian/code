public static class Functional
{
    public static Func&lt;T, TResult&gt; Lambda&lt;T, TResult&gt;(Func&lt;T, TResult&gt; func)
    {
        return func;
    }
}
