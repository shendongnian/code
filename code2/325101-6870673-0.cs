        [Pure]
        public static bool IsUri(this string str)
        {
            Contract.Ensures(!Contract.Result<bool>() || str != null); // by Dan Bryant
            var result = Uri.IsWellFormedUriString(str, UriKind.Absolute);
            Contract.Assume(!result || str != null); 
            return result;
        }
