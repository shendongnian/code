     public class AccessTokenStorage
    {
        private readonly IJSRuntime _jsRuntime;
        public AccessTokenStorage(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        public async Task<string> GetTokenAsync()
            => await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "accessToken");
        public async Task SetTokenAsync(string token)
        {
            if (token == null)
            {
                await _jsRuntime.InvokeAsync<object>("localStorage.removeItem", 
                                                                "accessToken");
            }
            else
            {
                await _jsRuntime.InvokeAsync<object>("localStorage.setItem", 
                                                       "accessToken", token);
            }
          
         }
        }
