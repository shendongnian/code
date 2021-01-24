        List<HashSet<char>> _charCombinations = new List<HashSet<char>> {
            new HashSet<char> {'a','@'},
            new HashSet<char> {'o', '0'},
        };
        HashSet<char> GetAlternatives(char c)
        {
            var result = new HashSet<char>();
            foreach (var hashSet in _charCombinations)
            {
                if (hashSet.Contains(c))
                {
                    foreach (char c2 in hashSet)
                        result.Add(c2);
                }
            }
            if (char.IsLetter(c))
            {
                result.Add((String.Empty + c).ToUpper()[0]);
                result.Add((String.Empty + c).ToLower()[0]);
            }
            else if (false) // any other char.Is-based logic
            {
            }
            result.Add(c);
            return result;
        }
        IEnumerable<string> GetTransformations(string s, int start)
        {
            char c = s[start - 1];
            foreach (var c2 in GetAlternatives(c))
            {
                if (start == s.Length)
                    yield return String.Empty + c2;
                else
                {
                    var e = GetTransformations(s, start + 1).GetEnumerator();
                    while (e.MoveNext())
                        yield return  c2 + e.Current;
                }
            }
        }
