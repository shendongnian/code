            const int AsciiRange = 127;
            const char ReplaceCharacter = '-';
            string input = "blah blah `";
            char[] chars = input.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] > AsciiRange)
                {
                    chars[i] = ReplaceCharacter;
                }
            }
            string output = new string(chars);
