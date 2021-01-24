    public class MyClass2 : IEquatable<MyClass2>
    {
        public KeyValuePair<EquatableIntArray, string> KeyValuePair { get; set; }
        public override bool Equals(object obj)
        {
            return Equals(obj as MyClass2);
        }
        public bool Equals(MyClass2 other)
        {
            return other != null &&
                   EqualityComparer<KeyValuePair<EquatableIntArray, string>>.Default.Equals(KeyValuePair, other.KeyValuePair);
        }
        private int? cachedHashCode;
        public override int GetHashCode()
        {
            if (cachedHashCode.HasValue) return cachedHashCode.Value;
            cachedHashCode = CombineHashCodes(KeyValuePair.Key.GetHashCode(), KeyValuePair.Value.GetHashCode());
            return cachedHashCode.Value;
        }
        
        internal static int CombineHashCodes(int h1, int h2)
        {
            return (((h1 << 5) + h1) ^ h2);
        }
    }
