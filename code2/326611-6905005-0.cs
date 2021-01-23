    public static XDocument Load(XmlReader reader, LoadOptions options)
    {
        if (reader == null)
        {
            throw new ArgumentNullException("reader"); //ArgumentNullException
        }
        if (reader.ReadState == ReadState.Initial)
        {
            reader.Read();// Could throw XmlException according to MSDN
        }
        XDocument document = new XDocument();
        if ((options & LoadOptions.SetBaseUri) != LoadOptions.None)
        {
            string baseURI = reader.BaseURI;
            if ((baseURI != null) && (baseURI.Length != 0))
            {
                document.SetBaseUri(baseURI);
            }
        }
        if ((options & LoadOptions.SetLineInfo) != LoadOptions.None)
        {
            IXmlLineInfo info = reader as IXmlLineInfo;
            if ((info != null) && info.HasLineInfo())
            {
                document.SetLineInfo(info.LineNumber, info.LinePosition);
            }
        }
        if (reader.NodeType == XmlNodeType.XmlDeclaration)
        {
            document.Declaration = new XDeclaration(reader);
        }
        document.ReadContentFrom(reader, options); // InvalidOperationException
        if (!reader.EOF)
        {
            throw new InvalidOperationException(Res.GetString("InvalidOperation_ExpectedEndOfFile")); // InvalidOperationException
        }
        if (document.Root == null)
        {
            throw new InvalidOperationException(Res.GetString("InvalidOperation_MissingRoot")); // InvalidOperationException
        }
        return document;
    }
 
