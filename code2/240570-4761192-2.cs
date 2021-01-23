            Dictionary<char, char> lookup = new Dictionary<char, char>
            {
                { '` ', '-' },
                //next pair...,
                //etc, etc.
            };
            string input = "blah blah ` blah";
            char[] chars = input.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                char replaceChar;
                if (lookup.TryGetValue(chars[i], out replaceChar))
                {
                    chars[i] = replaceChar;
                }
            }
            string output = new string(chars);
