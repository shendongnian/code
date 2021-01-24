     public class AuthenticatedHttp : HttpClientHandler
        {
            private readonly string Token;
            public AuthenticatedHttp(string token)
            {
                if (token == null)
                {
                    throw new ArgumentNullException(nameof(token));
                }
                this.Token = token;
            }
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                // See if the request has an authorize header
                var token = this.Token;
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            }
        }
