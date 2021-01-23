    internal class MatchIterator : IEnumerable
    {
        private class MatchEnumerator : IEnumerator
        {
            int index = 0;
            private Match currentMatch;
            private MatchNode current;
            readonly Regex regex;
            readonly string input;
            public MatchEnumerator(Regex regex, string input)
            {
                this.regex = regex;
                this.input = input;
            }
            public Match Current { get { return current; } }
    
            public void Reset() { throw new NotSupportedException(); }
            public bool MoveNext()
            {
                currentMatch = (currentMatch == null) ? regex.Match(input) : currentMatch.NextMatch();
                if (currentMatch.Success)
                {
                    current = new MatchNode(++index, currentMatch.Value);
                    return true;
                }
                return false;
            }
        }
        private Regex _regex;
        private string _input;
    
        public MatchIterator(string input, string pattern)
        {
            _regex = new Regex(pattern, UserDefinedFunctions.Options);
            _input = input;
        }
    
        public IEnumerator GetEnumerator()
        {
            return new MatchIterator(_input, _regex);
        }
    }
