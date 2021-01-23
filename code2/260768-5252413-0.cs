    using (strMem = new MemoryStream((byte[])attDr["filedata"]))
    {
        using (strWriter = new StreamWriter(strMem))
        {
            strWriter.Flush(); strMem.Position = 0;
            using (attachment = new Attachment(attDr["filename"].ToString()))
            {
                strMem.CopyTo(attachment.ContentStream);
                msg.Attachments.Add(attachment);
            }
        }
    }
            
