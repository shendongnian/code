    namespace System
    {
        [ComVisible(true)]
        public struct Boolean : IComparable, IConvertible, IComparable<Boolean>, IEquatable<Boolean>
        {
            public static readonly string TrueString;
            public static readonly string FalseString;
            public static Boolean Parse(string value);
            ...
        }
    }
