    public static class LegacyStaticClass
    {
        // A static constructor sets up all the delegates so production keeps working as usual
        static LegacyStaticClass()
        {
            ResetDelegates();
        }
        public static void ResetDelegates()
        {
            // All the logic that used to be in the body of the static method goes into the delegates instead.
            ThrowMeDelegate = input => throw input;
            SumDelegate = (a, b) => a + b;
        }
        public static Action<Exception> ThrowMeDelegate;
        public static Func<int, int, int> SumDelegate;
        public static void ThrowMe<TException>() where TException : Exception, new()
            => ThrowMeDelegate(new TException());
        public static int Sum(int a, int b)
            => SumDelegate(a, b);
    }
