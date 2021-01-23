    using static _globals;
    static class _globals
    {
        [MethodImpl(MethodImplOptions.NoInlining), DebuggerHidden]
        public static void Nop<T>(out T x) => x = default(T);
    };
    class Program
    {
        static void Main()
        {
            int i;     // unreferenced variable
            /// ...
            Nop(out i);
            /// ...
        }
    };
