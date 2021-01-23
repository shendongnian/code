    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace org.openrdf.repository {
        public class Repository {
        }
    }
    
    namespace CSLib
    {
    
        [System.AttributeUsage(System.AttributeTargets.Interface)]
        public class TypeExtensionPoint : System.Attribute
        {
            public TypeExtensionPoint()
            {
            }
        }
    
    
        [TypeExtensionPoint]
        public interface ISparqlCommand
        {
            string Name { get; }
            object Run(Dictionary<string, string> NamespacesDictionary, org.openrdf.repository.Repository repository, params object[] argsRest);
        }
    
    }
