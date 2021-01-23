namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            (new Program()).Entrance();
        }
        public void Entrance()
        {
            ABC a = new ABC();
            a.eventX += callback;
        }
        protected bool callback(int a)
        {
            return true;
        }
    }
    class ABC
    {
        public delegate bool X(int a);
        public event X eventX;
    }
}
