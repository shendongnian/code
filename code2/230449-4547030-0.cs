    public static void WriteElementContent(this XmlWriter writer, string content)
    {
        if (String.IsNullOrEmpty(content))
        {
            return;
        }
        // WriteString will happily escape any XML markup characters. However, 
        // for legibility we write content that contains certain special
        // characters as CDATA 
        const string SpecialChars = @"<>&";
        if (content.IndexOfAny(SpecialChars.ToCharArray()) != -1)
        {
            writer.WriteCData(content);
        }
        else
        {
            writer.WriteString(content);
        }
    }
