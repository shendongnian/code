    public static string RemoveInvalidXmlChars(string text)
        {
            if (text == null) return text;
            if (text.Length == 0) return text;
            // a bit complicated, but avoids memory usage if not necessary
            StringBuilder result = null;
            for (int i = 0; i < text.Length; i++)
            {
                var ch = text[i];
                if (XmlConvert.IsXmlChar(ch))
                {
                    result?.Append(ch);
                }
                else
                {
                    if (result == null)
                    {
                        result = new StringBuilder();
                        result.Append(text.Substring(0, i));
                    }
                }
            }
            if (result == null)
                return text; // no invalid xml chars detected - return original text
            else
                return result.ToString();
        }
