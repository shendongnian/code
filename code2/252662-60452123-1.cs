        namespace System
        {
            [ComVisible(true)]
            public struct Int32 : IComparable, IFormattable, IConvertible, IComparable<Int32>, IEquatable<Int32>
            {      
                public const Int32 MaxValue = 2147483647;     
                public const Int32 MinValue = -2147483648;
                public static Int32 Parse(string s, NumberStyles style, IFormatProvider provider);    
                ... 
            }  
        }
    
