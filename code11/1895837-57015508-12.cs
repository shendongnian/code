    using Microsoft.AspNetCore.Authorization;
    using System.Linq;
    
    namespace ApiAuthorized.Security
    {
        public class ResourceAuthorizeAttribute : AuthorizeAttribute
        {
            private string _resourceName = string.Empty;
            private string _resourceRoles;
    
            public ResourceAuthorizeAttribute(string resourceName)
            {
                _resourceName = resourceName ?? string.Empty;
            }
     
            public string ResourceRoles {
                get
                {
                    return _resourceRoles;
                }
                set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        Roles = string.Join(',',
                            value.Split(',')
                            .Select(role => $"{_resourceName.Trim().ToUpper()}:{role.Trim().ToUpper()}"));
                    }
                    _resourceRoles = value;
                }
            }
        }
    }
