    String ffFileName = HttpContext.Current.Request.Headers["X-File-Name"];
    if ((null == ffFileName) && (0 == context.Request.Files.Count))
      return;
    string tempDir = ConfigurationSettings.AppSettings["FilesTempDir"];
    string filePath = String.Format("{0}{1}", tempDir, Guid.NewGuid().ToString());
    if (null != ffFileName)
    {
      Stream inputStream = HttpContext.Current.Request.InputStream;
      byte[] fileBytes = ReadFully(inputStream);
      File.WriteAllBytes(filePath, fileBytes);
    }
    else
    {
      HttpPostedFile file = context.Request.Files[0];
      file.SaveAs(filePath);
      
    }
	
    context.Response.ContentType = "text/html";
    context.Response.Write("{\"success\": true}");
