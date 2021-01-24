    public ActionResult DownloadFile()
    {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                var stream = new FileStream(fullyQualifiedFileName, FileMode.Open);
                result.Content = new StreamContent(stream);
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                result.Content.Headers.ContentLength = stream.Length;
    
                string input = $"filename=test.pdf";
                ContentDispositionHeaderValue contentDisposition = null;
                if (ContentDispositionHeaderValue.TryParse(input, out contentDisposition))
                {
                    result.Content.Headers.ContentDisposition = contentDisposition;
                }
    
                return this.ResponseMessage(result);
    }
