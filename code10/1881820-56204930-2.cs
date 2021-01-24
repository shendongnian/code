    public class AuthenticationDelegatingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await GetToken();
            request.Headers.Authorization = new AuthenticationHeaderValue(token.Scheme, token.AccessToken);
            var response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
            {
                token = await RefreshToken();
                request.Headers.Authorization = new AuthenticationHeaderValue(token.Scheme, token.AccessToken);
                response = await base.SendAsync(request, cancellationToken);
            }
            return response;
        }
    }
