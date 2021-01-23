        /// <summary>
        /// <para>Tests if a file name matches the given wildcard pattern, uses the same rule as shell commands.</para>
        /// </summary>
        /// <param name="pattern">A wildcard pattern which can use char * to match any amount of characters; or char ? to match one character.</param>
        /// <param name="unixStyle">If true, use the *nix style wildcard rules; otherwise use windows style rules.</param>
        /// <returns>true if the file name matches the pattern, false otherwise.</returns>
        public static bool MatchesWildcard(this string fileName, string pattern, bool unixStyle)
        {
            if (unixStyle)
                return WildcardMatches(pattern, fileName, true);
            var filePieces = fileName.Split('.');
            var patternPieces = pattern.Split('.');
            var prevEndsWithAsterisk = false;
            for (var i = 0; i < filePieces.Length; i++)
            {
                if (patternPieces.Length - 1 < i)
                    return prevEndsWithAsterisk;
                var f = filePieces[i];
                var p = patternPieces[i];
                if (p.Length == 0)
                    return false;
                if (!WildcardMatches(p, f, false))
                    return false;
                prevEndsWithAsterisk = p.EndsWith("*");
            }
            if (patternPieces.Length > filePieces.Length)
            {
                var pRest = Enumerable.Range(filePieces.Length, patternPieces.Length - filePieces.Length)
                                      .Select(x => patternPieces[x])
                                      .ToList();
                var nonEmptyIndex = pRest.FindIndex(x => x.Length > 0);
                var lastEmptyIndex = pRest.FindLastIndex(x => x.Length == 0);
                return (nonEmptyIndex < lastEmptyIndex || nonEmptyIndex == -1 || lastEmptyIndex == -1) &&
                       pRest.All(x => x.All(c => c == '*' || c == '?'));
            }
            return true;
        }
        private static bool WildcardMatches(string pattern, string text, bool unixStyle)
        {
            var regex = "^" + Regex.Escape(pattern)
                              .Replace("\\*", ".*")
                              .Replace("\\?", unixStyle
                                                  ? "."
                                                  : ".?")
                   + "$";
            return Regex.IsMatch(text, regex, unixStyle
                                                  ? RegexOptions.None
                                                  : RegexOptions.IgnoreCase);
        }
