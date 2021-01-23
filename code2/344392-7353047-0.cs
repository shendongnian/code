        static void Main(string[] args)
        {
            Method<int>(Action);
        }
        static void Action(int arg)
        {
            // ...
        }
        static void Method<T>(Action<T> action)
        {
            // ...
        }
