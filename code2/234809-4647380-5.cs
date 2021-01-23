    public static class InstanceCounter<T>
    {
        private static int _counter;
        public static int Count { get { return _counter; }}
        public static void Increase()
        {
            _counter++;
        }
    
        public static void Decrease()
        {
            _counter--;
        }
    }
