    namespace System
    {
        public static class Extenders
        {
            public static string Join(this string separator, bool removeNullsAndWhiteSpaces, params string[] args)
            {
                return removeNullsAndWhiteSpaces ? string.Join(separator, args?.Where(s => !string.IsNullOrWhiteSpace(s))) : string.Join(separator, args);
            }
            public static string Join(this string separator, bool removeNullsAndWhiteSpaces, IEnumerable<string> args)
            {
                return removeNullsAndWhiteSpaces ? string.Join(separator, args?.Where(s => !string.IsNullOrWhiteSpace(s))) : string.Join(separator, args);
            }
        }
    }
