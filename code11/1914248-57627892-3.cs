    public class LetterCounter
    {
        private readonly Dictionary<char, int> _dictionary;
        private readonly Dictionary<char, char> _specialRules;
        public readonly HashSet<char> _allowedCharacters;
    
        public LetterCounter()
        {
            _dictionary = new Dictionary<char, int>();
            _specialRules = new Dictionary<char, char>();
            _allowedCharacters = new HashSet<char>();
        }
    
        public void RegisterCharacters(string str)
        {
            foreach (var @char in str) _allowedCharacters.Add(@char);
        }
    
        public void RegisterChar(char @char) => _allowedCharacters.Add(@char);
    
        public void RegisterCharGroupRule(CharGroupRule rule)
        {
            _allowedCharacters.Add(rule.MainChar);
            foreach (var mappedCharacter in rule.MappedCharacters) _specialRules[mappedCharacter] = rule.MainChar;
        }
    
        public IEnumerable<(char @char, int count)> ProcessString(string str)
        {
            _dictionary.Clear();
            foreach (var @char in str)
            {
                if (!_allowedCharacters.Contains(@char)) continue;
    
                var localChar = @char;
                if (_specialRules.ContainsKey(localChar)) localChar = _specialRules[localChar];
    
                if (_dictionary.ContainsKey(localChar)) _dictionary[localChar]++;
                else _dictionary[localChar] = 1;
            }
    
            return _dictionary.Select(c => (c.Key, c.Value)).OrderBy(c => c.Key);
        }
    }
