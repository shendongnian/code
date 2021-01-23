    public static class MyExtensions
    {
        public static Func<int,int, int> _doSumm = (x, y) => x + y;
        public static int Summ(this int x, int y)
        {
            return _doSumm(x, y);
        }
    }
