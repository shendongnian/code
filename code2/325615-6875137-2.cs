    #region WriteResponse(HttpContext context, Guid id)
    /// <summary>
    /// Writes the content for a media resource with the specified <paramref name="id"/> 
    /// to the response stream using the appropriate content type and length.
    /// </summary>
    /// <param name="context">The <see cref="HttpContext"/> to write content to.</param>
    /// <param name="id">The unique identifier assigned to the media resource.</param>
    private static void WriteResponse(HttpContext context, Guid id)
    {
        using(var connection = ConnectionFactory.Create())
        {
            using (var command = new SqlCommand("[dbo].[GetResponse]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
    
                command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
                command.Parameters.AddReturnValue();
    
                command.Parameters["@Id"].Value = id;
    
                command.Open();
    
                using(var reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    if(reader.Read())
                    {
                        WriteResponse(context, reader);
                    }
                }
            }
        }
    }
    #endregion
    
    #region WriteResponse(HttpContext context, SqlDataReader reader)
    /// <summary>
    /// Writes the content for a media resource to the response stream using the supplied <paramref name="reader"/>.
    /// </summary>
    /// <param name="context">The <see cref="HttpContext"/> to write content to.</param>
    /// <param name="reader">The <see cref="SqlDataReader"/> to extract information from.</param>
    private static void WriteResponse(HttpContext context, SqlDataReader reader)
    {
        if (context == null || reader == null)
        {
            return;
        }
    
        DateTime expiresOn      = DateTime.UtcNow;
        string contentType      = String.Empty;
        long contentLength      = 0;
        string fileName         = String.Empty;
        string fileExtension    = String.Empty;
    
        expiresOn               = reader.GetDateTime(0);
        fileName                = reader.GetString(1);
        fileExtension           = reader.GetString(2);
        contentType             = reader.GetString(3);
        contentLength           = reader.GetInt64(4);
    
        context.Response.AddHeader("Content-Disposition", String.Format(null, "attachment; filename={0}", fileName));
    
        WriteResponse(context, reader, contentType, contentLength);
    
        ApplyCachePolicy(context, expiresOn - DateTime.UtcNow);
    }
    #endregion
    
    #region WriteResponse(HttpContext context, SqlDataReader reader, string contentType, long contentLength)
    /// <summary>
    /// Writes the content for a media resource to the response stream using the 
    /// specified reader, content type and content length.
    /// </summary>
    /// <param name="context">The <see cref="HttpContext"/> to write content to.</param>
    /// <param name="reader">The <see cref="SqlDataReader"/> to extract information from.</param>
    /// <param name="contentType">The content type of the media.</param>
    /// <param name="contentLength">The content length of the media.</param>
    private static void WriteResponse(HttpContext context, SqlDataReader reader, string contentType, long contentLength)
    {
        if (context == null || reader == null)
        {
            return;
        }
    
        int ordinal     = 5;
        int bufferSize  = 4096 * 1024; // 4MB
        byte[] buffer   = new byte[bufferSize];
        long value;
        long dataIndex;
    
        context.Response.Buffer         = false;
        context.Response.ContentType    = contentType;
        context.Response.AppendHeader("content-length", contentLength.ToString());
    
        using (var writer = new BinaryWriter(context.Response.OutputStream))
        {
            dataIndex   = 0;
            value       = reader.GetBytes(ordinal, dataIndex, buffer, 0, bufferSize);
    
            while(value == bufferSize)
            {
                writer.Write(buffer);
                writer.Flush();
    
                dataIndex   += bufferSize;
                value       = reader.GetBytes(ordinal, dataIndex, buffer, 0, bufferSize);
            }
    
            writer.Write(buffer, 0, (int)value);
            writer.Flush();
        }
    }
    #endregion
