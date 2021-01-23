        /// <summary>
        /// <para>Tests if a file name matches the given wildcard pattern, uses the same rule as shell commands.</para>
        /// </summary>
        /// <param name="fileName">The file name to test, without folder.</param>
        /// <param name="pattern">A wildcard pattern which can use char * to match any amount of characters; or char ? to match one character.</param>
        /// <param name="unixStyle">If true, use the *nix style wildcard rules; otherwise use windows style rules.</param>
        /// <returns>true if the file name matches the pattern, false otherwise.</returns>
        public static bool MatchesWildcard(this string fileName, string pattern, bool unixStyle)
        {
            if (fileName == null)
                throw new ArgumentNullException("fileName");
            if (pattern == null)
                throw new ArgumentNullException("pattern");
            if (unixStyle)
                return WildcardMatchesUnixStyle(pattern, fileName);
            return WildcardMatchesWindowsStyle(fileName, pattern);
        }
        private static bool WildcardMatchesWindowsStyle(string fileName, string pattern)
        {
            var dotdot = pattern.IndexOf("..", StringComparison.Ordinal);
            if (dotdot >= 0)
            {
                for (var i = dotdot; i < pattern.Length; i++)
                    if (pattern[i] != '.')
                        return false;
            }
            var normalized = Regex.Replace(pattern, @"\.+$", "");
            var endsWithDot = normalized.Length != pattern.Length;
            var endWeight = 0;
            if (endsWithDot)
            {
                var lastNonWildcard = normalized.Length - 1;
                for (; lastNonWildcard >= 0; lastNonWildcard--)
                {
                    var c = normalized[lastNonWildcard];
                    if (c == '*')
                        endWeight += short.MaxValue;
                    else if (c == '?')
                        endWeight += 1;
                    else
                        break;
                }
                if (endWeight > 0)
                    normalized = normalized.Substring(0, lastNonWildcard + 1);
            }
            var endsWithWildcardDot = endWeight > 0;
            var endsWithDotWildcardDot = endsWithWildcardDot && normalized.EndsWith(".");
            if (endsWithDotWildcardDot)
                normalized = normalized.Substring(0, normalized.Length - 1);
            normalized = Regex.Replace(normalized, @"(?!^)(\.\*)+$", @".*");
            var escaped = Regex.Escape(normalized);
            string head, tail;
            if (endsWithDotWildcardDot)
            {
                head = "^" + escaped;
                tail = @"(\.[^.]{0," + endWeight + "})?$";
            }
            else if (endsWithWildcardDot)
            {
                head = "^" + escaped;
                tail = "[^.]{0," + endWeight + "}$";
            }
            else
            {
                head = "^" + escaped;
                tail = "$";
            }
            if (head.EndsWith(@"\.\*") && head.Length > 5)
            {
                head = head.Substring(0, head.Length - 4);
                tail = @"(\..*)?" + tail;
            }
            var regex = head.Replace(@"\*", ".*").Replace(@"\?", "[^.]?") + tail;
            return Regex.IsMatch(fileName, regex, RegexOptions.IgnoreCase);
        }
        private static bool WildcardMatchesUnixStyle(string pattern, string text)
        {
            var regex = "^" + Regex.Escape(pattern)
                                   .Replace("\\*", ".*")
                                   .Replace("\\?", ".")
                        + "$";
            return Regex.IsMatch(text, regex);
        }
