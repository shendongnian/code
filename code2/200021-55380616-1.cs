        public static string CleanXml(string text)
        {
            int length = text.Length;
            StringBuilder stringBuilder = new StringBuilder(length);
            for (int i = 0; i < length; ++i)
            {
                if (text[i] == '&')
                {
                    var remaining = Math.Abs(length - i + 1);
                    var subStrLength = Math.Min(remaining, 12);
                    var subStr = text.Substring(i, subStrLength);
                    var firstIndexOfSemiColon = subStr.IndexOf(';');
                    if (firstIndexOfSemiColon > -1)
                        subStr = subStr.Substring(0, firstIndexOfSemiColon + 1);
                    var matches = Regex.Matches(subStr, "&(?!quot;|apos;|amp;|lt;|gt;|#x?.*?;)|'");
                    if (matches.Count > 0)
                        stringBuilder.Append("&amp;");
                    else
                        stringBuilder.Append("&");
                }
                else if (XmlConvert.IsXmlChar(text[i]))
                {
                    stringBuilder.Append(text[i]);
                }
                else if (i + 1 < length && XmlConvert.IsXmlSurrogatePair(text[i + 1], text[i]))
                {
                    stringBuilder.Append(text[i]);
                    stringBuilder.Append(text[i + 1]);
                    ++i;
                }
            }
            return stringBuilder.ToString();
        }
