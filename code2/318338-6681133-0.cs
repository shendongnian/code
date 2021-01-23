    public struct SafeThing<T> where T : struct
    {
        private object boxedThing;
        public SafeThing(T value)
        {
            boxedThing = value;
        }
        public T Value { get { return (T) boxedThing; } }
        public static implicit operator T(SafeThing<T> value)
        {
            return value.Value; 
        }
        public static implicit operator SafeLong<T>(T value)
        {
            return new SafeLong(value); 
        }
    }
