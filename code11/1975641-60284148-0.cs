    using Microsoft.JSInterop;
    public class TokenProvider
    {
        private readonly IJSRuntime JSRuntime;
        public TokenProvider(IJSRuntime JSRuntime)
        {
            this.JSRuntime= JSRuntime;
        }
        public async Task<string> GetTokenAsync()
            => await JSRuntime.InvokeAsync<string>("localStorage.getItem", 
                                                             "authToken");
        public async Task SetTokenAsync(string token)
        {
            if (token == null)
            {
                await JSRuntime.InvokeAsync<object>("localStorage.removeItem", 
                                                                "authToken");
            }
            else
            {
                await JSRuntime.InvokeAsync<object>("localStorage.setItem", 
                                                       "authToken", token);
            }
              
        }
       
     }
