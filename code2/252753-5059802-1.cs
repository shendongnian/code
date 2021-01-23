    void Main()
    {
        const int iterations = 10 * 1000 * 1000;
        
    	// JIT preheat
        Test1(1);
        Test2(1);
        
        Stopwatch sw = Stopwatch.StartNew();
        Test1(iterations);
        sw.Stop();
        Debug.WriteLine("KeyValuePair: " + sw.ElapsedMilliseconds + "ms");
    
        sw = Stopwatch.StartNew();
        Test2(iterations);
        sw.Stop();
        Debug.WriteLine("MyKeyValuePair: " + sw.ElapsedMilliseconds + "ms");
    }
    
    public static void Test1(int iterations)
    {
        for (int index = 0; index < iterations; index++)
        {
            var kvp = new KeyValuePair<int, int>(index, index);
            kvp.GetHashCode();
        }
    }
    
    public static void Test2(int iterations)
    {
        for (int index = 0; index < iterations; index++)
        {
            var kvp = new MyKeyValuePair<int, int>(index, index);
            kvp.GetHashCode();
        }
    }
    
    public struct MyKeyValuePair<TKey, TValue>
    {
        private readonly TKey _Key;
        private readonly TValue _Value;
        
        public MyKeyValuePair(TKey key, TValue value)
        {
            _Key = key;
            _Value = value;
        }
        
        public TKey Key { get { return _Key; } }
        public TValue Value { get { return _Value; } }
        
        public int GetHashCode()
        {
            unchecked
            {
                int result = 37;
                
                result *= 23;
                if (Key != null)
                    result += Key.GetHashCode();
                    
                result *= 23;
                if (Value != null)
                    result += Value.GetHashCode();
                    
                return result;
            }
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(MyKeyValuePair<TKey, TValue>))
                return false;
                
            var other = (MyKeyValuePair<TKey, TValue>)obj;
            return Equals(other.Key, Key) && Equals(other.Value, Value);
        }
    }
