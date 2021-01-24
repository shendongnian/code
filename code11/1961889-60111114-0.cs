      public HttpResponseMessage GenrateFile(Stream stream, string fileName)
      {
            HttpResponseMessage response;
            response = Request.CreateResponse(HttpStatusCode.OK);
            MediaTypeHeaderValue mediaType = new MediaTypeHeaderValue("text/csv");
            response.Content = new StreamContent(stream);
            response.Content = response.Content;
            response.Content.Headers.ContentType = mediaType;
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = reportName;
            return response;
       }
