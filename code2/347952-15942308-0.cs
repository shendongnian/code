     private static object GetResultFromStaticMethodClass(string qualifiedClassName, string method)
     {
          Type StaticClass = Type.GetType(qualifiedClassName);
          MethodInfo methodInfo = StaticClass.GetMethod(method);
          object result = methodInfo.Invoke(null, null);
          return result;
     }
