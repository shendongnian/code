    using System;
    using Microsoft.AspNetCore.Mvc.Routing;
    public sealed class MyAttribute : Attribute
    {
        private string _someParameter;
        public IUrlHelperFactory UrlHelperFactory { get; set; }
        public MyAttribute(string someParameter)
        {
            _someParameter = someParameter;
        }
    }
