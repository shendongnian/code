    using System.Reflection;
    using System.Web.Mvc;
    
    namespace Tests.Extensions
    {
        public static class JsonExtensions
        {
            public static object GetPropertyValue(this JsonResult json, string propertyName)
            {
                return json.Data.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public).GetValue(json.Data, null);
            }
        }
    }
