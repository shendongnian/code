            string content = GetCsvStuffFromSomewhere();
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
            
            var response = new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StreamContent(stream)
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
            return response;
