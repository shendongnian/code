    public struct SafeThing<T> where T : struct
    {
        private object boxedThing;
        public SafeThing(T value)
        {
            boxedThing = value;
        }
        public T Value { get { return boxedThing == null ? default(T) : (T)boxedThing; } }
        public static implicit operator T(SafeThing<T> value)
        {
            return value.Value; 
        }
        public static implicit operator SafeThing<T>(T value)
        {
            return new SafeThing(value); 
        }
    }
