    using System.Linq;
    
    namespace System {
        static class StringExtensions {
            public static string ToHexColor(this string text) {
                if (text == null) text = string.Empty;
                int hash = text.GetHashCode();
                return $"#{hash:X8}";
            }
        }
    }
