    static class MathUtil
    {
        public static void UpTo(this int n, Action<int> proc)
        {
            for (int i = 0; i < n; i++)
                proc(i);
        }
    }
