    public sealed class XYZProxyHandler : DelegatingHandler
    {
       // If needed some thread-safe service, repo, etc can be passed in the constructor.
        /*
        private readonly ISmth _smth;
        public XYZProxyHandler(ISmth smth) 
        {
            _smth = smth;
        }
        */
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = request.Headers.GetCookies().FirstOrDefault().Cookies.FirstOrDefault(x => x.Name.ToLower() == "access_token").Value;
            var _var1 = GetVar1(token);
            var _var2 = GetVar2(token);
            
            SomeMethod(_var1, _var2);
            
            // ..
        }
        
        private void SomeMethod(string one, string two) {
          
          
        }
    }  
  
