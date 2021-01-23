    if (context.HttpContext.Response.IsClientConnected)
    {
     // Read the data in buffer.
     if (dataToRead>=10000)
     {
       byte[] buffer = new byte[10000];
       length = 10000
       context.HttpContext.Response.OutputStream.Write(buffer, 0, length);
     }
     else
     {
       byte[] buffer = new byte[dataToRead];
       length = buffer.Length;
       context.HttpContext.Response.OutputStream.Write(buffer, 0, length);  
     }
     // Flush the data to the HTML output.
     context.HttpContext.Response.Flush();
    
     dataToRead = dataToRead - length;
    }
