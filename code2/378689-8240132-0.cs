        [WebInvoke(Method = "POST", UriTemplate = "{importFile}")]
        public HttpResponseMessage Upload(string importFile, HttpRequestMessage request)
        {
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            // Read the MIME multipart content using the stream provider we just created.
            var task = request.Content.ReadAsMultipartAsync();            
            task.Wait();
            IEnumerable<HttpContent> bodyparts = task.Result;
            string submitter;
            if (!bodyparts.TryGetFormFieldValue("submitter", out submitter))
            {
                submitter = "unknown";
            }
            var parser = this.parserFactoryFactory.CreateParser();
            foreach (var part in bodyparts)
            {
                using (var stream = part.ContentReadStream)
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        string content = streamReader.ReadToEnd();
                        var results = parser.Parse(content);
                        if (results.IsValid)
                        {
                             
                        }
                    }
                }
            }
            var message = new HttpResponseMessage(HttpStatusCode.Accepted);
            return message;
        }  
