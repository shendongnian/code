    if (!ModelState.IsValid)
    {
      IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
      foreach (ModelError item in allErrors)
      {
            orderErrors += item.ErrorMessage;
            break;
      }
      using (var stream = new MemoryStream())
      {
                        
          var context = (HttpContextBase)Request.Properties["MS_HttpContext"];
          context.Request.InputStream.Seek(0, SeekOrigin.Begin);
          context.Request.InputStream.CopyTo(stream);
          string requestBody = Encoding.UTF8.GetString(stream.ToArray());
          
          log.write_to_log(requestBody, "null", "ModelState is not valid - " + orderErrors); //Saves to your log 
           return new HttpResponseMessage((HttpStatusCode)400);
       }
    }
    if (orderErrors != "")
    {
          return new HttpResponseMessage((HttpStatusCode)400);
    }
    else 
    {
         //Something happens
    }
