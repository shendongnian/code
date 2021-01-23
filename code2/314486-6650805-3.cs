    internal static class DelegateStore<T> {
         internal static IDictionary<string, Func<T>> Store = new ConcurrentDictionary<string,Func<T>>();
    }
    public static T CreateInstance<T>(Type objType) where T : class
    {
        Func<T> returnFunc;
        if(!DelegateStore<T>.Store.TryGetValue(objType.FullName, out returnFunc)) {
            var dynMethod = new DynamicMethod("DM$OBJ_FACTORY_" + objType.Name, objType, null, objType);
            ILGenerator ilGen = dynMethod.GetILGenerator();
            ilGen.Emit(OpCodes.Newobj, objType.GetConstructor(Type.EmptyTypes));
            ilGen.Emit(OpCodes.Ret);
            returnFunc = (Func<T>)dynMethod.CreateDelegate(typeof(Func<T>));
            DelegateStore<T>.Store[objType.FullName] = returnFunc;
        }
        return returnFunc();
    }
