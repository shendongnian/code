    using System;
    using Microsoft.AspNetCore.Mvc.Routing;
    internal class InversionOfControlAttribute : Attribute
    {
        private string _someString;
        private IUrlHelperFactory _urlHelperFactory;
        public InversionOfControlAttribute(string someString)
        {
            _someString = someString;
        }
        public void InjectServices(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }
