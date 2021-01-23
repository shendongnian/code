    public static void GetMIME(StreamWriter writer, NotesMIMEEntity mimeEntity)
    {
        try
        {
            string contentType = null;
            string headers = null;
            string content = null;
            string preamble = null;
            MIME_ENCODING encoding;
            contentType = mimeEntity.ContentType;
            headers = mimeEntity.Headers;
            encoding = mimeEntity.Encoding;
            // message envelope. If no MIME-Version header, add one
            if (!headers.Contains("MIME-Version:"))
                writer.WriteLine("MIME-Version: 1.0");
            writer.WriteLine(headers);
            // for multipart, usually no main-msg content...
            content = mimeEntity.ContentAsText;
            if (content != null && content.Trim().Length > 0)
                writer.WriteLine(content);
            writer.Flush();
            if (contentType.StartsWith("multipart"))
            {
                preamble = mimeEntity.Preamble;
                NotesMIMEEntity mimeChild = mimeEntity.GetFirstChildEntity();
                while (mimeChild != null)
                {
                    GetMimeChild(writer, mimeChild);
                    mimeChild = mimeChild.GetNextSibling();
                }
            }
            writer.WriteLine(mimeEntity.BoundaryEnd);
            writer.Flush();
        }
        catch (Exception ex)
        {
            Logging.Log(ex.ToString());
        }
    } 
    private void GetMimeChild(StreamWriter writer, NotesMIMEEntity mimeEntity)
    {
        string contentType = null;
        string headers = null;
        string content = null;
        string preamble = null;
        MIME_ENCODING encoding;
        contentType = mimeEntity.ContentType;
        headers = mimeEntity.Headers;
        encoding = mimeEntity.Encoding;
        if (encoding == MIME_ENCODING.ENC_IDENTITY_BINARY)
        {
            mimeEntity.EncodeContent(MIME_ENCODING.ENC_BASE64);
            headers = mimeEntity.Headers;
        }
        preamble = mimeEntity.Preamble;
        writer.Write(mimeEntity.BoundaryStart);
 
        if (!content.EndsWith("\n"))
            writer.WriteLine("");
        writer.WriteLine(headers);
        writer.WriteLine();
        writer.Write(mimeEntity.ContentAsText);
        if (contentType.StartsWith("multipart"))
        {
            preamble = mimeEntity.Preamble;
            NotesMIMEEntity mimeChild = mimeEntity.GetFirstChildEntity();
            while (mimeChild != null)
            {
                GetMimeChild(writer, mimeChild);
                mimeChild = mimeChild.GetNextSibling();
            }
        }
        writer.Write(mimeEntity.BoundaryEnd);
        writer.Flush();
    }
