    public void AddAttachmentToDB(
        XmlNode root, 
        XmlNamespaceManager xmlns, 
        string MessageID, 
        string MailBoxAliasName
    )
    {
        var strMailBoxAliasName = MailBoxAliasName;
        var AttachmentFilename = "yumyum";
        var AttachmentStream = "Cheetos";
        var strMessageID = "123";
        var strMailBoxAliasName = "user";
        var strfiletype = ".txt";
        var strAttachmentID = "12345";
  
        // Use DateTime when working with dates
        var dates123 = new DateTime(2011, 2, 3);
    
        try
        {
            using (var conn = new SqlConnection(DbConnectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = @"INSERT INTO MailboxListenerAttachments Values (@attachmentfilename, @attachmentbody, @messageID, @mailboxname, @filetype, @attachmentID, @DateAddedToDB";
                cmd.Parameters.AddWithValue("@attachmentfilename", AttachmentFilename);
                cmd.Parameters.AddWithValue("@attachmentbody", AttachmentStream.Trim());
                cmd.Parameters.AddWithValue("@messageID", strMessageID);
                cmd.Parameters.AddWithValue("@mailboxname", strMailBoxAliasName);
                cmd.Parameters.AddWithValue("@filetype", strfiletype);
                cmd.Parameters.AddWithValue("@attachmentID", strAttachmentID);
                cmd.Parameters.AddWithValue("@DateAddedToDB", dates123);
    
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            // TODO: Log the exception and propagate it
            throw ex;
        }
    }
