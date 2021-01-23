        private static readonly Regex _foo = new Regex(@"\\foo\\(?! (bar|baz)\\)",
            RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
        private static readonly Regex _foobar = new Regex(@"\\foo\\bar\\",
            RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
        private static readonly Regex _foobaz = new Regex(@"\\foo\\baz\\",
            RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
...
            foreach (var filename in files)
            {
                if (_foo.IsMatch(filename))
                {
                    // bucket foo
                }
                else if (_foobar.IsMatch(filename))
                {
                    // bucket foobar
                }
                else if (_foobaz.IsMatch(filename))
                {
                    // bucket foobaz
                }
            }
