    using (var content = new MultipartFormDataContent())
    {
      content.Add(CreateFileContent(vm[0]);
      content.Add(CreateFileContent(vm[1]);
      var response = await client.PostAsync(url, content);
      response.EnsureSuccessStatusCode();
    }
  
    private StreamContent CreateFileContent(AppFileDTO appFileDTO)
    {
      var fileContent = new StreamContent(appFileDTO.File.Stream);//your file stream
      fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
         {
            Name = "\"files\"",
            FileName = "\"" + appFileDTO.File.FileName + "\"",           
         }; // the extra quotes are key here
      fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");  
      fileContent.Headers.ContentDisposition.Parameters.Add(new NameValueHeaderValue("CategoryName",appFileDTO.CategoryName));      
      fileContent.Headers.ContentDisposition.Parameters.Add(new NameValueHeaderValue("CategoryDescription", appFileDTO.CategoryDescription));   
      fileContent.Headers.ContentDisposition.Parameters.Add(new NameValueHeaderValue("Detail", appFileDTO.Detail));   
      return fileContent;
    }
