    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace FooBar
    {
        class ControlResolver
        {
            const string BaseNamespace = "TheBaseControlNameSpace";
    
            readonly IDictionary<Type, string> resolvedPaths = new Dictionary<Type, string>();
    
            /// <summary>
            /// Maps types to partial paths for controls.
            /// 
            /// This is required for Types which are NOT automatically resolveable
            /// by the simple reflection mapping.
            /// </summary>
            static readonly IDictionary<Type, string> MappedPartialPaths = new Dictionary<Type, string>
            {
                { typeof(MyOddType), "~/VIRTUAL/PATH.ASCX" },
            };
    
            /// <summary>
            /// Given a type, return the partial path to the ASCX.
            /// 
            /// This path is the path UNDER the Control Template root
            /// WITHOUT the ASCX extension.
            /// 
            /// This is required because there is no mapping maintained between the class
            /// and the code-behind path.
            /// 
            /// Does not return null.
            /// </summary>
            public string ResolvePartialPath (Type type)
            {
                if (type == null)
                {
                    throw new ArgumentNullException("type");
                }
    
                string partialPath;
                if (resolvedPaths.TryGetValue(type, out partialPath))
                {
                    return partialPath;
                } else
                {
                    string mappedPath;
                    if (MappedPartialPaths.TryGetValue(type, out mappedPath))
                    {
                        resolvedPaths[type] = mappedPath;
                        return mappedPath;
                    } else
                    {
                        // Since I use well-mapped virtual directory names to namespaces,
                        // this gets around needing to manually specify all the types above.
                        if (!type.FullName.StartsWith(BaseNamespace))
                        {
                            throw new InvalidOperationException("Invalid control type");
                        } else
                        {
                            var reflectionPath = type.FullName
                                .Replace(BaseNamespace, "")
                                .Replace('.', '/');
                            resolvedPaths[type] = reflectionPath;
                            return reflectionPath;
                        }
                    }
                }
            }
        }
    }
