        [Pure]
        public static bool IsUri(this string str)
        {
            Contract.Ensures(!Contract.Result<bool>() || str != null); // by Dan Bryant
            return Uri.IsWellFormedUriString(str, UriKind.Absolute);
        }
