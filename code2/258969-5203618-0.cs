        public static unsafe string StripTabsAndNewlines(string s)
        {
            int len = s.Length;
            char* newChars = stackalloc char[len];
            char* currentChar = newChars;
            for (int i = 0; i < len; ++i)
            {
                char c = s[i];
                switch (c)
                {
                    case '\r':
                    case '\n':
                    case '\t':
                        continue;
                    default:
                        *currentChar++ = c;
                        break;
                }
            }
            return new string(newChars, 0, (int)(currentChar - newChars));
        }
