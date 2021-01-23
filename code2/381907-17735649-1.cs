    public static string RemoveInvalidXmlChars(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;
    
        int length = text.Length;
        StringBuilder stringBuilder = new StringBuilder(length);
    
        for (int i = 0; i < length; ++i)
        {
            if (XmlConvert.IsXmlChar(text[i]))
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
