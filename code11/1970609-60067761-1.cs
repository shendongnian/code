    public static T CallNonPublicMethod<T>(this object o, string methodName, params object[] args)
            {
                var type = o.GetType();
                var mi = type.GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
    
                if (mi != null)
                {
                    return (T)mi.Invoke(o, args);
                }
    
                throw new Exception($"Method {methodName} does not exist on type {type.ToString()}");
            }
    
    public static T CallNonPublicProperty<T>(this object o, string methodName)
            {
                var type = o.GetType();
                var mi = type.GetProperty(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
    
                if (mi != null)
                {
                    return (T)mi.GetValue(o);
                }
    
                throw new Exception($"Property {methodName} does not exist on type {type.ToString()}");
            }
