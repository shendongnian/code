    public class Box
    {
        internal Box()
        { }
        public static Box<T> ItUp<T>(T value)
            where T : struct
        {
            return value;
        }
        public static T ItOut<T>(object value)
            where T : struct
        {
            var tbox = value as Box<T>;
            if (!object.ReferenceEquals(tbox, null))
                return tbox.Value;
            else
                return (T)value;
        }
    }
    public sealed class Box<T> : Box
        where T : struct
    {
        public static IEqualityComparer<T> EqualityComparer { get; set; }
        private static readonly ConcurrentStack<Box<T>> _cache = new ConcurrentStack<Box<T>>();
        public T Value
        {
            get;
            private set;
        }
        static Box()
        {
            EqualityComparer = EqualityComparer<T>.Default;
        }
        private Box()
        {
        }
        ~Box()
        {
            if (_cache.Count < 4096) // Note this will be approximate.
            {
                GC.ReRegisterForFinalize(this);
                _cache.Push(this);
            }
        }
        public static implicit operator Box<T>(T value)
        {
            Box<T> box;
            if (!_cache.TryPop(out box))
                box = new Box<T>();
            box.Value = value;
            return box;
        }
        public static implicit operator T(Box<T> value)
        {
            return ((Box<T>)value).Value;
        }
        public override bool Equals(object obj)
        {
            var box = obj as Box<T>;
            if (!object.ReferenceEquals(box, null))
                return EqualityComparer.Equals(box.Value, Value);
            else if (obj is T)
                return EqualityComparer.Equals((T)obj, Value);
            else
                return false;
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
    
    // Sample usage:
    var boxed = Box.ItUp(100);
    LegacyCode(boxingIsFun);
    void LegacyCode(object boxingIsFun)
    {
      var value = Box.ItOut<int>(boxingIsFun);
    }
