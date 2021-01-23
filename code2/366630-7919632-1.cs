    using System;
    using System.Reflection;
    
    public class AttributeValidationMbro : MarshalByRefObject
    {
       public override object InitializeLifetimeService()
       {
          // infinite lifetime
          return null;
       }
    
       public bool ValidateAssembly(string pathToAssembly)
       {
          Assembly assemblyToExamine = Assembly.LoadFrom(pathToAssembly);
    
          bool hasAttribute = false;
    
          // TODO: examine the assemblyToExamine to see if it has the attribute
    
          return hasAttribute;
       }
    }
