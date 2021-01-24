    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    
    namespace AspNetCoreFilterDemo.Filters
    {
        public class AuthorizationFilterWithFactoryAttribute : Attribute, IFilterFactory
        {
            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }
    
            private class InternalAuthorizationFilter : IAuthorizationFilter
            {
                public InternalAuthorizationFilter()
                {
                    //This InternalAuthorizationFilter constructor will be called per http request rather than ASP.NET Core lifetime
                }
    
                public void OnAuthorization(AuthorizationFilterContext context)
                {
                    //OnAuthorization method will be called per http request
                }
            }
    
            public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
            {
                //Create InternalAuthorizationFilter instance per http request
                return new InternalAuthorizationFilter();
            }
        }
    }
