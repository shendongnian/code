        [Pure]
        public static bool IsUri(this string str)
        {
            Contract.Ensures(str != null);
            return Uri.IsWellFormedUriString(str, UriKind.Absolute);
        }
