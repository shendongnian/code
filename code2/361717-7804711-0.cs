    using System;
    namespace YOUR NAME SPACE
    {
        public static class StringExtensionMethods
        {
            /// <summary>
            /// Extention method to allow a string comparison where you can supply the comparison type 
            /// (i.e. ignore case, etc).
            /// </summary>
            /// <param name="value">The compare string.</param>
            /// <param name="comparisionType">The comparison type - enum, use OrdinalIgnoreCase to ignore case.</param>
            /// <returns>Returns true if the string is present within the original string.    </returns>
            public static bool Contains(this string original, string value, StringComparison comparisionType)
            {
                return original.IndexOf(value, comparisionType) >= 0;
            }
        }
    }
