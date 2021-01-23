    /// <summary>
    /// Convert the message body into a Hash value
    /// </summary>
    /// <param name="MessageBody">XElement holding all the message body XML nodes</param>
    /// <returns>a base 64 string representing the hash code</returns>
    private string GenerateMessageBodyHash(XElement MessageBody)
    {
        string hash = string.Empty;
        try
        {
            using( MemoryStream ms = new MemoryStream() )
            {
                XmlWriterSettings xws = new XmlWriterSettings();
                xws.OmitXmlDeclaration = true;
                xws.Indent = false;
   
                using( XmlWriter xw = XmlWriter.Create( ms, xws ))
                {
                    SHA256 shaM = new SHA256Managed();
                    hash = Convert.ToBase64String(shaM.ComputeHash( ms ));
                }
            }
        }
        catch (Exception ex)
        {
            Log.WriteLine(Category.Warning, "Exception detected generating the XML hash", ex);
        }
        return hash;
    }
