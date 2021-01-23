    private static void GetMethodInfo(object className)
            {
                var methods = className.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public);
    
                foreach(var m in methods)
                {
                    var parameters = m.GetParameters();
                    var att = m.GetCustomAttributes(typeof (CustomAttribute), true);
                }
            }
