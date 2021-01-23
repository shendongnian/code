     if (brData.ChunkNo == 1)
        {
            
            // Set the Content-type of the file
            if (brData.MimeType.Length < 1)
            {
                mimeType = "application/unknown";
            }
            else
            {
                mimeType = brData.MimeType;
            }
            msbase64Out = new MemoryStream();
        }
    
        if (brData.bytesJustRead > 0)
        {
            fileMS.WriteTo(msbase64Out);
         
        }
    
   
       if (brData.bytesRemaining < 1)
        {
            byte[] imgBytes = msbase64Out.ToArray();
    
            string img64 = Convert.ToBase64String(imgBytes);
    
            viewdocWriter.WriteString(img64);
        }
