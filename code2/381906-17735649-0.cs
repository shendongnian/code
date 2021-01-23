    public static string RemoveInvalidXmlChars(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;
    
        int i = 0, length = text.Length;
        StringBuilder stringBuilder = new StringBuilder(length);
    
        while (i < length)
        {
            if (XmlConvert.IsXmlChar(text[i]))
            {
                stringBuilder.Append(text[i]);
                ++i;
                continue;
            }
    
            // Check if this is a surrogate pair
            if (i + 1 < length && XmlConvert.IsXmlSurrogatePair(text[i + 1], text[i]))
            {
                stringBuilder.Append(text[i]);
                stringBuilder.Append(text[i + 1]);
                i += 2;
                continue;
            }
        }
    
        return stringBuilder.ToString();
    }
