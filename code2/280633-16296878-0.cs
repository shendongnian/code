      string relative = "ClassLibrary1.dll";
                string absolute = Path.GetFullPath(relative);
    
                Assembly assembly = Assembly.LoadFile(absolute);
                System.Type assemblytype = assembly.GetType("ClassLibrary1.Class1");
                 object []argtoppass={1,2};
              var a =Activator.CreateInstance(assemblytype, argtoppass);
              System.Type type = a.GetType();
              if (type != null)
              {
                  string methodName = "add";
                  MethodInfo methodInfo = type.GetMethod(methodName);
                  object   result = methodInfo.Invoke(a, null);
    
                  int a1 = (int )result;
              }
