    using System;
    using Microsoft.AspNetCore.Mvc.Routing;
    internal class InversionOfControlAttribute : Attribute
    {
        private string _someParameter;
        public IUrlHelperFactory UrlHelperFactory { get; set; }
        public InversionOfControlAttribute(string someParameter)
        {
            _someParameter = someParameter;
        }
    }
