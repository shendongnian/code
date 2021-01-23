            Assembly assembly = Assembly.LoadFrom("yourApp.exe");
            Type[] types = assembly.GetTypes();
            foreach (Type t in types)
            {
                if (t.Name == "YourClass")
                {
                    MethodInfo method = t.GetMethod("YourMethod",
                    BindingFlags.Public | BindingFlags.Instance);
                    if (method != null)
                    {
                        ParameterInfo[] parameters = method.GetParameters();
                        object classInstance = Activator.CreateInstance(t, null);
                        var result = method.Invoke(classInstance, parameters.Length == 0 ? null : parameters);
                        
                        break;
                    }
                }
                             
            }
        
