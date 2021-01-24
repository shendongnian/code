    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Http;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    namespace Management.Ui.Services
    {
      public class TokenContainer
      {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TokenContainer(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected async Task AddRequestHeaders(HttpClient httpClient)
        {
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }
      }
    }
