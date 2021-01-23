        protected const int MaxLengthAllowed = 32765;
        private static string UnescapeString(string encodedString)
        {
            var charsProccessed = 0;
            var sb = new StringBuilder();
            while (encodedString.Length > charsProccessed)
            {
                var isLastIteration = encodedString.Substring(charsProccessed).Length < MaxLengthAllowed;
                var stringToUnescape = isLastIteration
                    ? encodedString.Substring(charsProccessed)
                    : encodedString.Substring(charsProccessed, MaxLengthAllowed);
                while (!Uri.IsWellFormedUriString(stringToUnescape, UriKind.RelativeOrAbsolute) || stringToUnescape.Length == 0)
                {
                    stringToUnescape = stringToUnescape.Substring(0, stringToUnescape.Length - 1);
                }
                sb.Append(Uri.UnescapeDataString(stringToUnescape));
                charsProccessed += stringToUnescape.Length;
            }
            return sb.ToString();
        }
