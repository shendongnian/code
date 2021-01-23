    using System.Web.Routing;
    using System.Collections.Specialized;
    
    namespace MyProject.Extensions
    {
        public static class CollectionExtensions
        {
            public static RouteValueDictionary ToRouteValueDictionary(this NameValueCollection collection)
            {
                var routeValueDictionary = new RouteValueDictionary();
                foreach (var key in collection.AllKeys)
                {
                    routeValueDictionary.Add(key, collection[key]);
                }
                return routeValueDictionary;
            }
        }
    }
