        public class ConnectionStringAccessor {
            private IHttpContextAccessor _httpContextAccessor;
            public ConnectionStringAccessor(IHttpContextAccessor httpContextAccessor)
            {
                _httpContextAccessor = httpContextAccessor;
            }
        
            public string GetConnectionString() {
                return  _httpContextAccessor.HttpContext.Request.Cookies["cookieName"].Value;
    //you can consider some encryption/decryption or whatever you need to.
            }
        }
