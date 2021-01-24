     public HttpResponseMessage PostHttpResponse(string requestUri, object data)
    {
        using (var client = CreateHttpClient())
        {
            try
            {
                HttpResponseMessage response = client.PostAsJsonAsync(requestUri, data).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
                else
                {
                    GetErrorsResponse(response);
                    throw new HttpRequestException(string.Format("There was an exception trying to post a request. response: {0}", response.ReasonPhrase));
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
                //return null;
            }
        }
    }
