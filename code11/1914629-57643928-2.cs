    public class MyClass{
        private readonly ICookieContainerAccessor accessor;
        private readonly TypedClient typedClient;
        public MyClass(TypedClient typedClient, ICookieContainerAccessor accessor) {
            this.accessor = accessor;
            this.typedClient = typedClient;
        }
    
        public async Task SomeMethodAsync() {
            // Need to call AddCookie method here           
            var cookieContainer = accessor.CookieContainer;
            AddCookies(cookieContainer);
            var response = await typedclient.client.GetAsync('/');
            //...
        }
        
        //...
    }
