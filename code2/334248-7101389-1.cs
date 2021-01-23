    context.Response.ContentType = "application/pdf";
    Stream fileStream = publishBookManager.GetFile(documentId);
    byte[] buffer = new byte[16 * 1024];
    using (MemoryStream ms = new MemoryStream())
    {
      int read;
      while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
      {
        ms.Write(buffer, 0, read);
      }
    }
    
    context.Response.BinaryWrite(data); 
    context.Response.Flush();   
