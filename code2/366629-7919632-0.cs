    using System;
    using System.Security.Policy;
    
    internal static class AttributeValidationUtility
    {
       internal static bool ValidateAssembly(string pathToAssembly)
       {
          AppDomain appDomain = null;
          try
          {
             appDomain = AppDomain.CreateDomain("ExaminationAppDomain", new Evidence(AppDomain.CurrentDomain.Evidence));
    
             AttributeValidationMbro attributeValidationMbro = appDomain.CreateInstanceAndUnwrap(
                                  typeof(AttributeValidationMbro).Assembly.FullName,
                                  typeof(AttributeValidationMbro).FullName) as AttributeValidationMbro;
    
             return attributeValidationMbro.ValidateAssembly(pathToAssembly);
          }
          finally
          {
             if (appDomain != null)
             {
                AppDomain.Unload(appDomain);
             }
          }
       }
    }
