    Attachable attachable = Helper.CreateAttachableUpload(//some params);
    byte[] bytes = //byte array;
    
    if (bytes != null)
    {
     using (MemoryStream stream = new MemoryStream(bytes))
     {
     attachable.FileName = //filename;
     attachable.ContentType = "image/jpeg";
     
     var attachableUploaded = serviceContext.Upload(serviceContext, attachable, stream);
     attachable = serviceContext.Upload(serviceContext, attachable, stream);
     stream.Close();
     }}
