       public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
            {
                // Summary:
                //     Called before the TokenEndpoint redirects its response to the caller.
                return Task.FromResult<object>(null);
            }
