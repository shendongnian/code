    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Dispatcher;
    using System.Web.Http.Routing;
    
    namespace WebApi
    {
    
        public class AcceptHeaderControllerSelector : IHttpControllerSelector
        {
            private const string ControllerKey = "controller";
            private const string ActionKey = "action";
            private const string VersionHeaderValueNotFoundExceptionMessage = "Version not found in headers";
            private const string VersionFoundInUrlAndHeaderErrorMessage = "Version can not be in Header and Url";
            private const string CouldNotFindEndPoint = "Could not find endpoint {0} for api version number {1}";
            private readonly HttpConfiguration _configuration;
            private readonly Dictionary<string, HttpControllerDescriptor> _controllers;
    
            public AcceptHeaderControllerSelector(HttpConfiguration config)
            {
                _configuration = config;
                _controllers = InitializeControllerDictionary();
            }
    
            private Dictionary<string, HttpControllerDescriptor> InitializeControllerDictionary()
            {
                var dictionary = new Dictionary<string, HttpControllerDescriptor>(StringComparer.OrdinalIgnoreCase);
                 
                var assembliesResolver = _configuration.Services.GetAssembliesResolver();
                // This would seem to look at all references in the web api project and find any controller, so I had to add Controller.V2 reference in order for it to find them
                var controllersResolver = _configuration.Services.GetHttpControllerTypeResolver();
    
                var controllerTypes = controllersResolver.GetControllerTypes(assembliesResolver);
    
                foreach (var t in controllerTypes)
                {
                    var segments = t.Namespace.Split(Type.Delimiter);
                    
                    // For the dictionary key, strip "Controller" from the end of the type name.
                    // This matches the behavior of DefaultHttpControllerSelector.
                    var controllerName = t.Name.Remove(t.Name.Length - DefaultHttpControllerSelector.ControllerSuffix.Length);
    
                    var key = string.Format(CultureInfo.InvariantCulture, "{0}{1}", segments[segments.Length - 1], controllerName);
      
                    dictionary[key] = new HttpControllerDescriptor(_configuration, t.Name, t);
                }
                
                return dictionary;
            }
            
            public HttpControllerDescriptor SelectController(HttpRequestMessage request)
            {
                IHttpRouteData routeData = request.GetRouteData();
    
                if (routeData == null)  
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
    
                var controllerName = GetRouteVariable<string>(routeData, ControllerKey);
                var actionName = GetRouteVariable<string>(routeData, ActionKey);
    
                if (controllerName == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
    
                var version = GetVersion(request);
    
                HttpControllerDescriptor controllerDescriptor;
    
                if (_controllers.TryGetValue(controllerName, out controllerDescriptor))
                {
                    if (!string.IsNullOrWhiteSpace(version))
                    {
                        throw new HttpResponseException(request.CreateResponse(HttpStatusCode.Forbidden, VersionFoundInUrlAndHeaderErrorMessage));
                    }
    
                    return controllerDescriptor;
                }
    
                controllerDescriptor = TryGetControllerWithMatchingMethod(version, controllerName, actionName);
    
                if (controllerDescriptor != null)
                {
                    return controllerDescriptor;
                }
               
                var message = string.Format(CouldNotFindEndPoint, controllerName, version);
    
                throw new HttpResponseException(request.CreateResponse(HttpStatusCode.NotFound, message));
            }
    
            private HttpControllerDescriptor TryGetControllerWithMatchingMethod(string version, string controllerName, string actionName)
            {
                var versionNumber = Convert.ToInt32(version.Substring(1, version.Length - 1));
                while(versionNumber >= 1) { 
                    var controllerFullName = string.Format("Namespace.Controller.V{0}.{1}Controller, Namespace.Controller.V{0}", versionNumber, controllerName);
                    Type type = Type.GetType(controllerFullName, false, true);
    
                    var matchFound = type != null && type.GetMethod(actionName) != null;
    
                    if (matchFound)
                    {
                        var key = string.Format(CultureInfo.InvariantCulture, "V{0}{1}", versionNumber, controllerName);
                        HttpControllerDescriptor controllerDescriptor;
                        if (_controllers.TryGetValue(key, out controllerDescriptor))
                        {
                            return controllerDescriptor;
                        }
                    }
                    versionNumber--;
                }
    
                return null;
            }
    
            public IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
            {
                return _controllers;
            }
    
            private string GetVersion(HttpRequestMessage request)
            {
                IEnumerable<string> values;
                string apiVersion = null;
    
                if (request.Headers.TryGetValues(Common.Classes.Constants.ApiVersion, out values))
                {
                    apiVersion = values.FirstOrDefault();
                }
    
                return apiVersion;
            }
            
            private static T GetRouteVariable<T>(IHttpRouteData routeData, string name)
            {
                object result = null;
                if (routeData.Values.TryGetValue(name, out result))
                {
                    return (T)result;
                }
                return default(T);
            }
        }
    }
