    using System.Linq;
    
    namespace System {
        static class StringExtensions {
            public static string ToHexColor(this string text) {
                if (text == null) text = string.Empty;
                int hash = text.GetHashCode();
                var bytes = BitConverter.GetBytes(hash);
                return "#" + string.Join(string.Empty, bytes.Select(b => $"{b:X2}"));
            }
        }
    }
