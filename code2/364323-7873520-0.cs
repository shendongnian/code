    public static class Mapper {
    
            /// <summary>
            /// Copy all not null properties values of object source in object target if the properties are present.
            /// Use this method to copy only simple type properties, not collections.
            /// </summary>
            /// <param name="source">source object</param>
            /// <param name="target">target object</param>
            private static void SimpleCopy(object source, object target)
            {
                foreach (PropertyInfo pi in source.GetType().GetProperties())
                {
                    object propValue = pi.GetGetMethod().Invoke(source, null);
                    if (propValue != null)
                    {
                        try
                        {
                            PropertyInfo pit = GetTargetProperty(pi.Name, target);
                            if (pit != null) pit.GetSetMethod().Invoke(target, new object[] { propValue });
                        }
                        catch (Exception) { /* do nothing */ }
                    }
                }
            }
            private static PropertyInfo GetTargetProperty(string name, object target) 
            {
                foreach (PropertyInfo pi in target.GetType().GetProperties()) 
                {
                    if (pi.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)) return pi;
                }
                return null;
            }
    
    }
