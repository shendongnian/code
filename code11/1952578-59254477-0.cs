    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    public sealed class PemissionAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _name;
        public PemissionAttribute(string name)
        {
            _name = name;
        }
        public string Name => _name;
        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];
        }
    }
