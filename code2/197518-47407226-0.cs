    private string[] GetCommaSeperatedWords(string sep, string line)
        {
            List<string> list = new List<string>();
            StringBuilder word = new StringBuilder();
            int doubleQuoteCount = 0;
            for (int i = 0; i < line.Length; i++)
            {
                string chr = line[i].ToString();
                if (chr == "\"")
                {
                    if (doubleQuoteCount == 0)
                        doubleQuoteCount++;
                    else
                        doubleQuoteCount--;
                    continue;
                }
                if (chr == sep && doubleQuoteCount == 0)
                {
                    list.Add(word.ToString());
                    word = new StringBuilder();
                    continue;
                }
                word.Append(chr);
            }
            list.Add(word.ToString());
            return list.ToArray();
        }
