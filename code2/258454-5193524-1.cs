    public static class BaseExtensions {
      public static void BaseCall(this object self, string methodName, params object[] parameters) {
        self.BaseCall(methodName, typeof(void), null, parameters);
      }
      public static T BaseCallWithReturn<T>(this object self, string methodName, T defaultReturn = default(T), params object[] parameters) {
        return (T)self.BaseCall(methodName, typeof(T), defaultReturn, parameters);
      }
      private static object BaseCall(this object self, string methodName, Type returnType, object defaultReturn, object[] parameters) {
        var parameterTypes = parameters.Select(p => p.GetType()).ToArray();
        if (self.GetType().BaseType == null) return null;
        var method = self.GetType().BaseType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, parameterTypes, null);
        if (method == null || method.IsAbstract) return defaultReturn;
        var dm = new DynamicMethod(methodName, returnType, new Type[] { self.GetType() }.Concat(parameterTypes).ToArray(), self.GetType());
        var il = dm.GetILGenerator();
        PushParameters(il, parameterTypes.Length);
        il.Emit(OpCodes.Call, method);
        il.Emit(OpCodes.Ret);
        return dm.Invoke(null, new object[] { self }.Concat(parameters).ToArray());
      }
      private static void PushParameters(ILGenerator il, int n) {
        il.Emit(OpCodes.Ldarg_0);
        for (int i = 0; i < n; ++i) {
          switch (i+1) {
            case 1: il.Emit(OpCodes.Ldarg_1); break;
            case 2: il.Emit(OpCodes.Ldarg_2); break;
            case 3: il.Emit(OpCodes.Ldarg_3); break;
            default: il.Emit(OpCodes.Ldarg_S, i); break;
          }
        }
      }
    }
