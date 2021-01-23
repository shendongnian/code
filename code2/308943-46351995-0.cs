        public static string CompactWhitespace(string astring)
        {
            if (!string.IsNullOrEmpty(astring))
            {
                bool found = false;
                StringBuilder buff = new StringBuilder();
                foreach (char chr in astring.Trim())
                {
                    if (char.IsWhiteSpace(chr))
                    {
                        if (found)
                        {
                            continue;
                        }
                        found = true;
                        buff.Append(' ');
                    }
                    else
                    {
                        if (found)
                        {
                            found = false;
                        }
                        buff.Append(chr);
                    }
                }
                return buff.ToString();
            }
            return string.Empty;
        }
