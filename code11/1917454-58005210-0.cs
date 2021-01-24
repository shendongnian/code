     public class AppGlobalHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var resp = await base.SendAsync(request, cancellationToken);
            var content = resp?.Content != null 
               ? (await resp.Content.ReadAsStringAsync()) 
               : string.Empty; 
            Debug.WriteLine($"Response:{request.RequestUri}{Environment.NewLine}{content}");
            return resp;
        }
    }
    
 
