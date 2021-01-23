    static public String GetExpandedInfo(Exception e)
    {
        StringBuilder info = new StringBuilder();
        Type exceptionType = e.GetType();
        // only get properties declared in this type (i.e. not inherited from System.Exception)
        PropertyInfo[] propertyInfo = exceptionType.GetProperties(System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        if (propertyInfo.Length > 0)
        {
            // add the exception class name at the top
            info.AppendFormat("[{0}]\n", exceptionType.Name);
            foreach (PropertyInfo prop in propertyInfo)
            {
                // check the property isn't overriding a System.Exception property (i.e. Message)
                // as that is a default property accessible via the generic Exception class handlers
                var getMethod = prop.GetGetMethod(false);
                if (getMethod.GetBaseDefinition().DeclaringType == getMethod.DeclaringType)
                {
                    // add the property name and it's value
                    info.AppendFormat("{0}: {1}\n", prop.Name, prop.GetValue(e, null));
                }
            }
        }
