    try
    {
        using(MemoryStream dataStream = Utility.GetFile())
        {
          // read from beginning 
          dataStream.Position = 0;
          
          HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
          httpResponseMessage.Content = new StreamContent(dataStream);
          httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
          httpResponseMessage.Content.Headers.ContentDisposition.FileName = "Test.xlsx";
          httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
          return httpResponseMessage;
        }
    }
    catch (Exception ex)
    {
        throw;
    }
