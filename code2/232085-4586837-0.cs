Does this do what you need?  You can modify it so the _charactersByIndex contains the digits as well.  Fix the 26 and 25 as well.
    public class LetterCounter
    {
        private static readonly string[] _charactersByIndex = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        
        private Dictionary<string, int> _countersByPrefix = new Dictionary<string, int>();
        public void ResetCounter() { _countersByPrefix.Clear(); }
        private string GetStr(int i)
        {
            if (i < 26)
                return _charactersByIndex[i];
            int x = i / 25 - 1;
            string a = _charactersByIndex[x];
            string b = GetStr(i - 25);
            return a + b;
        }
        public string GetNext(string namePrefix)
        {
            namePrefix = namePrefix.ToLower().Trim();
            lock (_countersByPrefix)
            {
                int c = 0;
                if (_countersByPrefix.ContainsKey(namePrefix))
                {
                    c = _countersByPrefix[namePrefix];
                    c++;
                    _countersByPrefix[namePrefix] = c;
                }
                else
                {
                    _countersByPrefix[namePrefix] = c;
                }
                return namePrefix + "__" + GetStr(c);
            }
        }
    }
