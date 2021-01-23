        object InvokeMethod(string assembly, string type, string method, object[] parameters)
        {
            Assembly asm = Assembly.LoadFrom(assembly);
            Type classtype = asm.GetType(type, true, false);
            object dynamicObject = Activator.CreateInstance(classtype);
          
            MethodInfo invokedMethod = classtype.GetMethod(method);
                
            return invokedMethod.Invoke(dynamicObject,parameters);
          
        }
