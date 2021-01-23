        [DebuggerNonUserCode]
        public static HttpWebResponse GetHttpResponse(this HttpWebRequest request) {
            // We know the response will be a HttpWebResponse because the request is a HttpWebRequest
            return (HttpWebResponse)request.GetResponse();
        }
        [DebuggerNonUserCode]
        public static HttpWebResponse GetHttpResponseAvoidVexingExceptions(this HttpWebRequest request) {
            try {
                return GetHttpResponse(request);
            } catch (WebException ex) {
                HttpWebResponse response = (HttpWebResponse)ex.Response;
                switch (response.StatusCode) {
                    case HttpStatusCode.NotModified:
                        return response;
                    default:
                        // We don't catch other exceptions
                        throw;
                }
            }
        }
    There's no way I'm aware of to avoid this exception.
