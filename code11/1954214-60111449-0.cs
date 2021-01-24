    public class CustomLogHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var logMetadata = await BuildRequestMetadata(request);
            var response = await base.SendAsync(request, cancellationToken);
            logMetadata = await BuildResponseMetadata(logMetadata, response);
            await SendToLog(logMetadata);
            return response;
        }
        private async Task<LogMetadata> BuildRequestMetadata(HttpRequestMessage request)
        {
            LogMetadata log = new LogMetadata
            {
                RequestMethod = request.Method.Method,
                RequestTimestamp = DateTime.Now,
                RequestUri = request.RequestUri.ToString(),
                RequestContent = await request.Content.ReadAsStringAsync(),
            };
            return log;
        }
        private async Task<LogMetadata> BuildResponseMetadata(LogMetadata logMetadata, HttpResponseMessage response)
        {
            logMetadata.ResponseStatusCode = response.StatusCode;
            logMetadata.ResponseTimestamp = DateTime.Now;
            logMetadata.ResponseContentType = response.Content == null ? string.Empty : response.Content.Headers.ContentType.MediaType;
            logMetadata.Response = await response.Content.ReadAsStringAsync();
            return logMetadata;
        }
        private async Task<bool> SendToLog(LogMetadata logMetadata)
        {
            try
            {
                //write your code
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
