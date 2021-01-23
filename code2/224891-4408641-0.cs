    namespace ExtensionMethods
    {
        public static class MyExtensions
        {
    
            public static bool IsFormatValid(this object target, string Format)
            {
               try 
               {
                   target.ToString(Format);
               }
               catch
               {
                   return false;
               }
               return true;
            }
        }
    }
