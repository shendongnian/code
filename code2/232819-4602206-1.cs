            Dictionary<char, char> lookup = new Dictionary<char, char>
            {
                { 'ஹ', '\x86' },
                //next pair...
            };
            string input = "ஹ";
            char[] chars = input.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                char replaceChar;
                if (lookup.TryGetValue(chars[i], out replaceChar))
                {
                    chars[i] = replaceChar;
                }
            }
            byte[] output = Encoding.GetEncoding("iso-8859-1").GetBytes(chars);
