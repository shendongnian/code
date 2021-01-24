    D2Document newDocument = new D2Document();
    newDocument.SetPropertyValue("object_name", fileName);
    newDocument.SetPropertyValue("a_content_type", contenType);
    String documentURL = ConfigurationManager.AppSettings["DOCUMENTUM_URL"] + "objects/"+ documentId + "/content-media?format=" + contenType + "&modifier=&page=0";
    JSON_GENERIC_MEDIA_TYPE = new MediaTypeWithQualityHeaderValue("application/json");
    JSON_VND_MEDIA_TYPE = new MediaTypeWithQualityHeaderValue("application/vnd.emc.documentum+json");
    try
        {
            using (var multiPartStream = new MultipartFormDataContent())
                {
                    MemoryStream stream = new MemoryStream();
                    JsonSerializer.WriteObject(stream, newDocument);
                    ByteArrayContent firstPart = new ByteArrayContent(stream.ToArray());
                    firstPart.Headers.ContentType = JSON_VND_MEDIA_TYPE;               
                   multiPartStream.Add(firstPart);
                   stream.Dispose();
                   HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, documentURL);
                   request.Content = multiPartStream;
                   String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
                   request.Headers.Add("Authorization", "Basic " + encoded);                      
                   using (HttpResponseMessage response = _httpClient.GetAsync(documentURL).Result)
                      {
                         if (response != null)
                            {
                               var responsestream = response.Content;
                             }}}}
