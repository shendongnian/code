    public static FileResult FileWebRequest(this Controller controller, Uri uri, 
      string contentType) 
    {
      return controller.FileWebResult(uri, contentType, null);
    }
    public static FileResult FileWebResult(this Controller controller, Uri uri, 
      string contentType, string fileDownloadName) 
    {
      WebRequest request = WebRequest.Create(uri);
      using (WebResponse response = request.GetResponse()) 
      {
        BinaryReader reader = new BinaryReader(response.GetResponseStream());
        byte[] buffer = new byte[response.ContentLength];
        using (Stream responseStream = response.GetResponseStream())
        using (MemoryStream memStream = new MemoryStream()) 
        {
          int bytesRead;
          int totalBytesRead = 0;
          while ((bytesRead = responseStream.Read(buffer, 0, buffer.Length)) > 0) 
          {
            memStream.Write(buffer, totalBytesRead, bytesRead);
          }
          FileResult result = new FileContentResult(memStream.ToArray(), contentType);
          if (fileDownloadName != null) {
            result.FileDownloadName = fileDownloadName;
          }
          return result;
        }
      }
    }
