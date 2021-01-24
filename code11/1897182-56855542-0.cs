           HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                 Content = new StreamContent(stream),
            };
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            {
                FileName = "Test.pdf"
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return ResponseMessage(result);
