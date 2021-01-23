            Assembly assembly = Assembly.Load("MyProject.Components");
            Type dllType = assembly.GetType("MynameSpace.MyClass");
            if (dllType != null)
            {
                MethodInfo m = dllType.GetMethod("MyFunction");
                object objdll;
                objdll = Activator.CreateInstance(dllType);
                // use the parameter information to construct the arguments
                ParameterInfo[] parameters = m.GetParameters();
                object[] args;
                if (parameters != null && parameters.Length > 0)
                {
                    args = new object[parameters.Length];
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        // check for factory attributes on the actual parameter
                        FactoryAttribute[] attributes = parameters[i].GetCustomAttributes(typeof(FactoryAttribute), true) as FactoryAttribute[];
                        // if no attributes were found, check the parameter type for factory attributes
                        if (attributes == null || attributes.Length == 0)
                            attributes = parameters[i].ParameterType.GetCustomAttributes(typeof(FactoryAttribute), true) as FactoryAttribute[];
                        // if no attributes were found still, then give up
                        if (attributes == null || attributes.Length == 0)
                        {
                            // this parameter has no factory specified,
                            // so how would this code know how to create the argument for that parameter ???
                            args[i] = null;
                            continue; // move on to the next parameter
                        }
                        // there should only be one factory attribute, so use the first one
                        // assumption made here is that all factory classes will have a parameterless constructor
                        IFactory factory = Activator.CreateInstance(attributes[0].FactoryType) as IFactory;
                        args[i] = factory.CreateInstance();
                    }
                }
                else
                    // there are no parameters
                    args = null;
                
                if ((m != null))
                {
                    strReturnValue += (string)m.Invoke(objdll, args);
                }
            }
