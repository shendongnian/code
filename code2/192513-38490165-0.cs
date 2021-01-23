    public sealed class String : IComparable, ICloneable, IConvertible, IComparable<string>, IEnumerable<char>, IEnumerable, IEquatable<string>
        {
            // Summary:
            //     Initializes a new instance of the System.String class to the value indicated
            //     by an array of Unicode characters.
            //
            // Parameters:
            //   value:
            //     An array of Unicode characters.
            [SecuritySafeCritical]
            public String(char[] value);
        }
