        public static IEnumerable<char> ReplaceMultiple(this IEnumerable<char> input, Dictionary<char, char> replaces) 
        {
            foreach(var character in input)
                yield return replaces.ContainsKey(character) ? replaces[character] : character;
        }
