        [Pure]
        public static bool IsUri(this string str)
        {
            if(String.IsNullOrWhiteSpace(str)) return false;
            return Uri.IsWellFormedUriString(str, UriKind.Absolute);
        }
