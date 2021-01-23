    try
       {
          System.String filename = "C:\\downloadJSP\\myFile.txt";
    
          // set the http content type to "APPLICATION/OCTET-STREAM
          Response.ContentType = "APPLICATION/OCTET-STREAM";
    
          // initialize the http content-disposition header to 
          // indicate a file attachment with the default filename
          // "myFile.txt"
          System.String disHeader = "Attachment;
          Filename=\"myFile.txt\"";
          Response.AppendHeader("Content-Disposition", disHeader);
    
          // transfer the file byte-by-byte to the response object
          System.IO.FileInfo fileToDownload = new
             System.IO.FileInfo(filename);
          System.IO.FileStream fileInputStream = new
            System.IO.FileStream(fileToDownload.FullName,
            System.IO.FileMode.Open, System.IO.FileAccess.Read);
          int i;
          while ((i = fileInputStream.ReadByte()) != - 1)
          {
             Response.Write((char)i);
          }
          fileInputStream.Close();
          Response.Flush();
          Response.Close();
       }
       catch (System.Exception e)
       // file IO errors
       {
          SupportClass.WriteStackTrace(e, Console.Error);
       }
