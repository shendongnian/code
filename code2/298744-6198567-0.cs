    byte[] buffer = new byte[8192];
    
    pdfStream.Seek(0, SeekOrigin.Begin);
    
    Response.ClearContent();
    Response.ClearHeaders();
    Response.BufferOutput = true;
    Response.ContentType = "application/pdf";
    
    int bytesRead = pdfStream.Read(buffer, 0, 8192);
    while(bytesRead > 0)
    {
    byte[] buffer2 = new byte[bytesRead];
    System.Buffer.BlockCopy(buffer, 0, buffer2, 0, bytesRead);
    
    Response.BinaryWrite(buffer2);
    Response.Flush();
    
    bytesRead = pdfStream.Read(buffer, 0, 8192);
    }
    Response.End();
