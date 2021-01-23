        public static IEnumerable<KeyValuePair<string, string>> Split(string text)
        {
            if (text == null)
                yield break;
            int keyStart = 0;
            int keyEnd = -1;
            int lastSpace = -1;
            for(int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    lastSpace = i;
                    continue;
                }
                if (text[i] == ':')
                {
                    if (lastSpace >= 0)
                    {
                        yield return new KeyValuePair<string, string>(text.Substring(keyStart, keyEnd - keyStart), text.Substring(keyEnd + 1, lastSpace - keyEnd - 1));
                        keyStart = lastSpace + 1;
                    }
                    keyEnd = i;
                    continue;
                }
            }
            if (keyEnd >= 0)
                yield return new KeyValuePair<string, string>(text.Substring(keyStart, keyEnd - keyStart), text.Substring(keyEnd + 1));
        }
