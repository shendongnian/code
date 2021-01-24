    using (var formDataImage = new MultipartFormDataContent())
    {                                                                                                                        
      formDataImage.Add(bytesContent, "image", "image");
      using (var httpImage = new HttpClient())
      {
         ServicePointManager.Expect100Continue = true;                                                                
         ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;                                                              
         httpImage.DefaultRequestHeaders.Add("Authorization", oAuthHeaderImage);                                                                
         var httpRespImage = httpImage.PostAsync(baseUrlImage, formDataImage);                                                                
         var respBodyImage = httpRespImage.Result;                                                                
         if (respBodyImage.StatusCode.ToString().ToLower() != "created")
         {
             string rspImage = httpRespImage.Exception.InnerException.ToString();                                                                    
         }
      }
    }
