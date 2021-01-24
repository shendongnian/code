    using (HttpResponseMessage response = _httpClient.GetAsync(documentURL).Result)
            {
                if (response != null)
                {
                 HttpContent content = response.Content;
                //Get the actual content stream
                Stream contentStream = content.ReadAsStreamAsyn().Result;
                //copy the stream to File Stream. "file" is the variable have the physical path location.
                contentStream.CopyTo(file);
                }
            }
